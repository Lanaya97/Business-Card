using BusinessCard.Application.Commands.BusinessCard.Delete;
using BusinessCard.Application.Common;
using BusinessCard.Application.Extensions;
using BusinessCard.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessCard.Application.Commands
{
    public sealed class DeleteBusinessCardCommandHandler : IRequestHandler<DeleteBusinessCardCommand, Result<bool>>
    {
        private readonly IBusinessCardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBusinessCardCommandHandler(IBusinessCardRepository repository, IUnitOfWork unitOfWork) 
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(DeleteBusinessCardCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var card = await _repository.FirstOrDefaultAsync(x => x.Id ==  request.Id).ConfigureAwait(false);

            card.Delete();

            //Soft deleteing the card here, if want to hard remove the record, we use _repository.Remove(card) instead of Update
            _repository.Update(card);
            await _unitOfWork.CompleteAsync();

            result.Data = true;
            result.Successful();

            return result;
        }
    }
}
