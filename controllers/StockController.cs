using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList()
            .Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] StockCreateRequestDto stockCreateDto)
        {
            var stock = stockCreateDto.ToStockFromCreateDto();
            _context.Stock.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction("GetById", new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StockUpdateRequestDto stockUpdateDto)
        {
            var stockModel = _context.Stock.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("We have stock update", stockModel);
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
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stock = _context.Stock.FirstOrDefault(x => x.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            _context.Stock.Remove(stock);
            _context.SaveChanges();
            return NoContent();
        }

    }
}