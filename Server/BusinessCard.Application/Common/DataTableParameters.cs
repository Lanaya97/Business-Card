using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace BusinessCard.Application.Common
{
    public class DataTablesParameters
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("order")]
        public Order? Order { get; set; }

        [JsonProperty("filters")]
        public List<Filter>? Filters { get; set; }


        public QueryOptions ToQueryOptions()
        {
            var options = new QueryOptions
            {
                PageNo = (Start / Math.Max(Length, 1)) + 1,
                PageSize = Math.Max(Length, 1),
                Skip = Start,
                Filters = Filters ?? new List<Filter>(),
            };

            if (Order != null)
            {
                options.Order = Order.Name;
                options.IsAscending = Order.Dir == "asc";
            }

            return options;
        }
    }

    public class Search
    {
        [JsonProperty("value")]
        public string? Value { get; set; }
        [JsonProperty("regex")]
        public bool Regex { get; set; }
    }

    public class Order
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dir")]
        public string Dir { get; set; }
    }
}
