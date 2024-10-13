using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using FluentValidation.Results;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);


        var validationTasks = _validators.Select(x => x.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(failure => failure.PropertyName)
            .Select(group => new ValidationFailure(group.Key, string.Join(", ", group.Select(x => x.ErrorMessage).Distinct())))
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
