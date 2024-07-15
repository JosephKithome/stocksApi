using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.helpers;
using api.interfaces;
using api.mappers;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationContext context,
        IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        
        }

        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> GetAll([FromQuery] GenericRequestFilter gf)
        {
            var stocks = await  _stockRepository.GetAllAsync(gf);
            var stockDto  = stocks.Select(s => s.ToStockDto());
            
            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await  _stockRepository.GetByIdAsync(id);
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
            await  _stockRepository.CreateAsync(stock);
            return CreatedAtAction("GetById", new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockUpdateRequestDto stockUpdateDto)
        {
           
         
            var stockModel =await _stockRepository.UpdateAsync(id,stockUpdateDto);
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await   _stockRepository.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
    
            return NoContent();
        }

    }
}