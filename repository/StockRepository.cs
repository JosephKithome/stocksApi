using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.helpers;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationContext _context;

        // Dependency Injection
        public StockRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async  Task<List<Stock>> GetAllAsync(GenericRequestFilter gf)
        {
            var stocks =  _context.Stock.Include(comment=> comment.Comments).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(gf.CompanyName)){
                stocks = stocks.Where(st => st.CompanyName.Contains(gf.CompanyName));
            }
            if(!string.IsNullOrWhiteSpace(gf.Symbol)){
                stocks = stocks.Where(st => st.Symbol.Contains(gf.Symbol));
            }
            if(!string.IsNullOrWhiteSpace(gf.SortBy)){
                if(gf.SortBy.Equals("symbol",StringComparison.OrdinalIgnoreCase)){
                    stocks = (bool)gf.IsDescending ? stocks.OrderByDescending(st => st.Symbol): stocks.OrderBy(st=> st.Symbol) ;
                }
                if(gf.SortBy.Equals("companyName")){
                    stocks = stocks.OrderBy(st => st.CompanyName);
                }
            }
            var skipNumber = (gf.Page-1) * gf.ItemsPerPage;

            return await stocks.Skip((int)skipNumber).Take((int)gf.ItemsPerPage).ToListAsync();
        }


        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(comment=> comment.Comments).FirstOrDefaultAsync(st => st.Id == id);

        }

        public async Task<Stock?> UpdateAsync(int id, StockUpdateRequestDto stockUpdateRequestDto)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(st => st.Id == id);
            if (existingStock == null)
            {
                return null;
            }

            // You can as well do the update here
            existingStock.Symbol = stockUpdateRequestDto.Symbol;
            existingStock.CompanyName = stockUpdateRequestDto.CompanyName;
            existingStock.Purchase = stockUpdateRequestDto.Purchase;
            existingStock.LastDiv = stockUpdateRequestDto.LastDiv;
            existingStock.Industry = stockUpdateRequestDto.Industry;
            await _context.SaveChangesAsync();

            return existingStock;
        }


        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(st => st.Id == id);
            if (stock == null)
            {
                return null;
            }
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;

        }

        public Task<bool> StockExistsAsync(int id)
        {
            return _context.Stock.AnyAsync(s=>s.Id ==id);
        }

    
    }
}