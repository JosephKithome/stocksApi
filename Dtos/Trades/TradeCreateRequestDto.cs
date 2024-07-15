using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Trades
{
    public class TradeCreateRequestDto
    {
        public decimal EntryPrice { get; set; }
        public decimal? ExitPrice { get; set; }
        public DateTime EntryDate {get; set;} = DateTime.Now;
        public DateTime? ExitDate {get; set;} = null;
        public decimal? TakeProfit {get; set;} = null;
        public decimal? StopLoss {get; set; } = null;
        public int PipSize {get; set; } = 0;
    }
}