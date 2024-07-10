using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> AddAsync(Comment comment);

        Task<Comment?> UpdateAsync(int id,CommentUpdateRequestDto commentUpdateRequestDto);
        Task<Comment> DeleteAsync(int id);
        
    }
}