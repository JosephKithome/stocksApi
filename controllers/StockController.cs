using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // Initializes the db connection
        private readonly ApplicationContext _context;

        public StockController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            var stocks = await  _context.Stock.ToListAsync();
            var stockDto  = stocks.Select(s => s.ToStockDto());
            
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await  _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockCreateRequestDto stockCreateDto)
        {
            var stock = stockCreateDto.ToStockFromCreateDto();
            await  _context.Stock.AddAsync(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockUpdateRequestDto stockUpdateDto)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }
            // You can as well do the update here
            stockModel.Symbol = stockUpdateDto.Symbol;
            stockModel.CompanyName = stockUpdateDto.CompanyName;
            stockModel.Purchase = stockUpdateDto.Purchase;
            stockModel.LastDiv = stockUpdateDto.LastDiv;
            stockModel.Industry = stockUpdateDto.Industry;
            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}