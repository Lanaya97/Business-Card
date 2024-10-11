using BusinessCard.Application.Common;
using BusinessCard.Application.Extensions;
using BusinessCard.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessCard.Application.Commands.BusinessCard.Create
{
    public sealed class CreateBusinessCardCommandHandler : IRequestHandler<CreateBusinessCardCommand, Result<Guid>>
    {
        private readonly IBusinessCardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBusinessCardCommandHandler(IBusinessCardRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(CreateBusinessCardCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<Guid>();

            var businessCard = Domain.BusinessCard.Create(request.Name,
                                                          request.Gender,
                                                          request.DateOfBirth,
                                                          request.Email,
                                                          request.CountryCode,
                                                          request.Phone,
                                                          request.Street,
                                                          request.City,
                                                          request.ZipCode,
                                                          request.Photo);

            await _repository.AddAsync(businessCard);

            await _unitOfWork.CompleteAsync();

            result.Data = businessCard.Id;
            result.Successful();

            return result;
        }
    }
}
