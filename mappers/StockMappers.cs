using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.controllers.Dtos.Stock;
using api.Dtos.Stock;
using api.Models;

namespace api.mappers
{
    public static class StockMappers
    {

        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }

        public static Stock ToStockFromCreateDto(this StockCreateRequestDto stockDto){
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
        
    }
}