using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using Microsoft.AspNetCore.Mvc;

using api.mappers;
using api.Dtos.Comment;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comment = await _commentRepository.GetAllAsync();
            var commentDto = comment.Select(s => s.MapToCommentDto());

            return Ok(commentDto);
        }

        // GET api/comment/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var commentDto = comment.MapToCommentDto();
            return Ok(commentDto);
        }

        // POST api/comment
        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CommentCreateRequestDto commentCreateDto)
        {
            if(ModelState.IsValid)
                return BadRequest(ModelState);
                
            if (!await _stockRepository.StockExistsAsync(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var commentModel = commentCreateDto.MapToComment(commentCreateDto);
            await _commentRepository.AddAsync(commentModel);
            return CreatedAtAction("GetById", new { id = commentModel.Id }, commentModel.MapToCommentDto());


        }

        // PUT api/comment/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CommentUpdateRequestDto commentUpdateDto)
        {
            var comment = await _commentRepository.UpdateAsync(id, commentUpdateDto);
            return Ok(comment.MapToCommentDto());

        }

        // DELETE api/comment/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}