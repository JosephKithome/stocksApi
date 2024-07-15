using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trades;
using api.Models;

namespace api.mappers
{
    public static class TrandeMapper
    {

        public static TradeDto MapTradeToDto(this Trade trade)
        {

            return new TradeDto
            {
                Id = trade.Id,
                EntryPrice = trade.EntryPrice,
                ExitPrice = trade.ExitPrice,
                EntryDate = trade.EntryDate,
                ExitDate = trade.ExitDate,
                TakeProfit = trade.TakeProfit,
                StopLoss = trade.StopLoss,
                PipSize = trade.PipSize,
                // StockId = trade.StockId

            };

        }

        public static Trade MapDtoToTrade(this TradeCreateRequestDto tradeDto)
        {

            return new Trade
            {
                EntryPrice = tradeDto.EntryPrice,
                ExitPrice = tradeDto.ExitPrice,
                EntryDate = tradeDto.EntryDate,
                ExitDate = tradeDto.ExitDate,
                TakeProfit = tradeDto.TakeProfit,
                StopLoss = tradeDto.StopLoss,
                PipSize = tradeDto.PipSize,
                // StockId = tradeDto.StockId
            };
    }
    }
    }