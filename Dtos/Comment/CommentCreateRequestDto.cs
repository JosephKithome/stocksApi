using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentCreateRequestDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "Should be at least 3 characters")]
         public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int StockId { get; set; }
       
    }
}