using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class CommentRepository : ICommentRepository

    {
        private readonly ApplicationContext _context;

        // Dependency Injection
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Comment> AddAsync(Comment comment)
        {
            await  _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
          return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
 
        }

        public async Task<Comment?>  DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                 return comment;
            }
            return null;
           
            
        }

        public async Task<Comment?> UpdateAsync(int id, CommentUpdateRequestDto commentUpdateRequestDto)
        {
             var existingComment = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);

            if (existingComment != null)
            {
                existingComment.Title = commentUpdateRequestDto.Title;
                existingComment.Content = commentUpdateRequestDto.Content;
                existingComment.StockId = commentUpdateRequestDto.StockId;
                await _context.SaveChangesAsync();
                return existingComment;
            }
            return null;
        }

    }
}