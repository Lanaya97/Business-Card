using BusinessCard.Application.Common;
using BusinessCard.Application.Extensions;
using FluentValidation;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BusinessCard.API.Middleware;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            if (ex is ValidationException)
            {
                if (ex.InnerException != null && ex.InnerException is not ValidationException)
                    _logger.LogError(ex.InnerException, message: ex.InnerException?.Message ?? string.Empty);

                Debug.WriteLine(ex.InnerException?.Message ?? string.Empty);
                await HandleExceptionAsync(context, ex.InnerException ?? ex);
            }
            else
            {
                _logger?.LogError(ex, ex.Message);

                Debug.WriteLine(ex.Message ?? string.Empty);
                await HandleExceptionAsync(context, ex);
            }
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = GetStatusCode(exception);

        if (exception is ValidationException)
        {
            Result<Dictionary<string, List<string>>> response = new();
            response.Failed().WithMessage(GetTitle(exception)).WithData(GetErrors(exception));
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        else
        {
            Result response = new();
            response.Failed().WithMessage(GetTitle(exception));
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {

            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            ApplicationException applicationException => applicationException.Message,
            ValidationException => "Validation Failed",
            _ => "Server Error",
        };

    private static Dictionary<string, List<string>> GetErrors(Exception exception)
    {
        Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        if (exception is ValidationException validationException)
        {
            foreach (var error in validationException.Errors)
            {
                if (errors.TryGetValue(error.PropertyName, out List<string>? value))
                    value.Add(error.ErrorMessage);
                else
                    errors[error.PropertyName] = new List<string>() { error.ErrorMessage };
            }
        }
        return errors;
    }
}