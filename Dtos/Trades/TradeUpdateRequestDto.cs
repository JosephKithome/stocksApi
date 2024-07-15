using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Trades
{
    public class TradeUpdateRequestDto
    {
        public decimal EntryPrice;
        public decimal? ExitPrice;
        public DateTime EntryDate = DateTime.Now;
        public DateTime? ExitDate;
        public decimal? TakeProfit;
        public decimal? StopLoss;

    }
}