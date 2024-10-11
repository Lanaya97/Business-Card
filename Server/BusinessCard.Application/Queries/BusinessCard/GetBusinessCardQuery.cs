using BusinessCard.Application.Common;
using BusinessCard.Application.ReadModels.BusinessCard;
using MediatR;
using System.Collections.Generic;

namespace BusinessCard.Application.Queries.BusinessCard
{
    public sealed class GetBusinessCardsQuery : IRequest<Result<List<BusinessCardReadModel>>>
    {
        public QueryOptions? Options { get; set; }
    }
}
