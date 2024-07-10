using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.mappers
{
    public static class CommentMapper
    {
        public static CommentDto MapToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                // CreatedOn = comment.CreatedOn,
                StockId = comment.StockId

            };
        }
        
        public static Comment MapToComment(this CommentCreateRequestDto commentDto, CommentCreateRequestDto commentCreateDto)
        {
            return new Comment
            {
                
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = commentDto.StockId,
                // CreatedOn = DateTime.Now

            };
        }
        
    }
}