using AutoMapper;
using BusinessCard.Application.Common;
using BusinessCard.Application.Extensions;
using BusinessCard.Application.Interfaces;
using BusinessCard.Application.ReadModels.BusinessCard;
using BusinessCard.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessCard.Application.Queries.BusinessCard
{
    public sealed class GetBusinessCardsQueryHandler : IRequestHandler<GetBusinessCardsQuery, Result<List<BusinessCardReadModel>>>
    {
        private readonly IBusinessCardRepository _repository;
        private readonly IMapper _mapper;

        public GetBusinessCardsQueryHandler(IBusinessCardRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<BusinessCardReadModel>>> Handle(GetBusinessCardsQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<List<BusinessCardReadModel>>();

            #region Filtering

            /// Filtering out soft deleted records.
            Expression<Func<Domain.BusinessCard, bool>> predicate = x => x.DateDeleted == null;

            foreach (var filter in request.Options.Filters)
            {
                switch (filter.Name)
                {
                    case "name":
                        predicate = predicate.And(x => x.Name.Contains(filter.Value));
                        break;
                    case "email":
                        predicate = predicate.And(x => x.Email.Contains(filter.Value));
                        break;
                    case "gender":
                        if(Enum.TryParse(filter.Value, true, out Gender gender))
                          predicate = predicate.And(x => x.Gender == gender);
                        break;
                    //case "dateOfBirth":
                    //    predicate = predicate.And(wh => (wh.IsActive == filter.ToBoolean()));
                    //    break;
                }
            }
            #endregion

            var pagingCriteria = new PagingCriteria<Domain.BusinessCard>(request.Options.PageNo, request.Options.PageSize);

            var data = await _repository.FindListAsync(predicate, pagingCriteria);
            var count = await _repository.GetCountAsync(predicate);

            result.Data = _mapper.Map<List<BusinessCardReadModel>>(data);
            result.AddMetadata("count", count);

            result.Successful();

            return result;
        }
    }
}
