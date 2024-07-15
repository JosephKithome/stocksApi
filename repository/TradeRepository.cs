using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trades;
using api.helpers;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class TradeRepository : ITradeRepository
    {
       private readonly ApplicationContext _context;
        public TradeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Trade> AddTradeAsync(Trade tradeModel)
        {
            await _context.Trade.AddAsync(tradeModel);
            await _context.SaveChangesAsync();
            return tradeModel;
        
        }

        public async Task<Trade> DeleteTradeAsync(int id)
        {
            var existingTrade = await _context.Trade.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTrade != null) {
                _context.Trade.Remove(existingTrade);
                await _context.SaveChangesAsync();
                return existingTrade;
            }
            return null;
        }

       public async Task<List<Trade>> GetAllTradesAsync(TradeGenericFilter filter)
        {
            var trades =  _context.Trade.Include(stock=> stock.Stock);
            return  await trades.ToListAsync();
            
        }

        public async Task<Trade?> GetTradeByIdAsync(int id)
        {
            return  await  _context.Trade.FirstOrDefaultAsync(t => t.Id == id);


        }

        public async Task<Trade?> UpdateTradeAsync(int tradeId, TradeUpdateRequestDto tradeUpdateRequestDto)
        {
            var existingTrade = await _context.Trade.FirstOrDefaultAsync(t => t.Id == tradeId);
            if(existingTrade != null){
                existingTrade.EntryPrice = tradeUpdateRequestDto.EntryPrice;
                existingTrade.ExitPrice = tradeUpdateRequestDto.ExitPrice;
                existingTrade.StopLoss = tradeUpdateRequestDto.StopLoss;
                existingTrade.TakeProfit = tradeUpdateRequestDto.TakeProfit;
                await _context.SaveChangesAsync();
                
            }
            return existingTrade;
        
        }
    }
}