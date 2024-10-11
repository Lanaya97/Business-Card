using System.Collections.Generic;

namespace BusinessCard.Application.Common
{
    public class QueryOptions
    {
        #region Private Members

        private int _pageNo = 1;
        private int _pageSize = 10;
        private string _orderBy = string.Empty;

        #endregion

        #region Public Members

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0 ? _pageSize : value;
        }

        public int PageNo
        {
            get => _pageNo;
            set => _pageNo = value <= 0 ? _pageNo : value;
        }

        public int Skip { get; set; }

        public List<Filter> Filters { get; set; }

        public string OrderBy
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_orderBy))
                {
                    return IsAscending
                        ? $"{_orderBy} asc"
                        : $"{_orderBy} desc";
                }
                return _orderBy;
            }
            set => _orderBy = value;
        }

        public string Order { get; set; } = string.Empty;
        public bool IsAscending { get; set; }
        #endregion
    }

    public class Filter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public FilterMatchingEnum FilterMatching { get; set; }
    }

    public enum FilterMatchingEnum
    {
        ExactMatch = 1,
        PartialMatch = 2,
        InList = 3
    }
}
