using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trades;
using api.helpers;
using api.interfaces;
using api.mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [ApiController]
    [Route("api/v1/trade")]
    public class TradeController: ControllerBase
    {
        private readonly ITradeRepository _tradeRepository;
        public TradeController(ITradeRepository tradeRep)
        {
            _tradeRepository = tradeRep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTradesAsync([FromQuery] TradeGenericFilter gf)
        {
            var trades =await  _tradeRepository.GetAllTradesAsync(gf);
            var tradesDto = trades.Select(x => x.MapTradeToDto());
            return Ok(tradesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradeByIdAsync(int id)
        {
            var trade = await _tradeRepository.GetTradeByIdAsync(id);
            if(trade is null)
                return NotFound();
            var tradeDto = trade.MapTradeToDto();
            return Ok(tradeDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTradeAsync([FromBody] TradeCreateRequestDto tradeDto)
        {
            var trade = tradeDto.MapDtoToTrade();
            await _tradeRepository.AddTradeAsync(trade);
            return CreatedAtAction(nameof(GetTradeByIdAsync), new { id = trade.Id }, trade);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTradeAsync(int id, [FromBody] TradeUpdateRequestDto tradeDto)
        {
            var tradeModel =await _tradeRepository.UpdateTradeAsync(id, tradeDto);
            return Ok(tradeModel.MapTradeToDto()); //
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeAsync(int id)
        {
            await _tradeRepository.DeleteTradeAsync(id);
            return NoContent();
        }
        
    }
}