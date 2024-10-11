using System;
using System.Linq.Expressions;

namespace BusinessCard.Application.Common
{
    public class PagingCriteria<T> where T : class
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public Expression<Func<T, object>> Order { get; private set; }
        public bool IsAscending { get; private set; }

        public PagingCriteria(int pageNumber = 1, int pageSize = 15, Expression<Func<T, object>> order = null, bool isAscending = true)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Order = order;
            IsAscending = isAscending;
        }
        public PagingCriteria(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
