using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Trades
{
    public class TradeDto
    {
         public int Id { get; set; }
        public decimal EntryPrice;
        public decimal? ExitPrice;
        public DateTime EntryDate = DateTime.Now;
        public DateTime? ExitDate;
        public decimal? TakeProfit;
        public decimal? StopLoss;
        public int PipSize;
        // private Stock stock;
        
    }
}