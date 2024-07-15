using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trades;
using api.helpers;
using api.Models;

namespace api.interfaces
{
    public interface ITradeRepository
    {
        Task <List<Trade>> GetAllTradesAsync(TradeGenericFilter gf);
        Task<Trade?> GetTradeByIdAsync(int id);
        Task<Trade> AddTradeAsync(Trade trade);
        Task<Trade?> UpdateTradeAsync(int tradeId, TradeUpdateRequestDto tradeUpdateRequestDto);
        Task<Trade?> DeleteTradeAsync(int id);
    }
}