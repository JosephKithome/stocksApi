using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.controllers.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, long.MaxValue)]
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}