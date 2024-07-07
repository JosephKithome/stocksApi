using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using Mysqlx.Crud;

namespace api.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id); // Bearing in Mind that FirstOrDefault can be  null;;
        Task<Stock> CreateAsync(Stock stockModel);
        Task <Stock>  UpdateAsync(int id, StockUpdateRequestDto stockUpdateRequestDto);
        Task<Stock> DeleteAsync(int id);

    }
}