using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.helpers
{
    public class TradeGenericFilter
    {
        public decimal? entryPrice { get; set; } = null;
        public decimal? exitPrice { get; set; } = null;
        public DateTime? entryDate { get; set; } = null;
        public DateTime? exitDate { get; set; } = null;
        public decimal? takeProfit { get; set; } = null;
        public decimal? stopLoss { get; set; }= null;
        public int pipSize { get; set; }= 0;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        
    }
}