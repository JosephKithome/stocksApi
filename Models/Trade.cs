using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Trade
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        [Required]
        public decimal EntryPrice { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal? ExitPrice { get; set; }

        public DateTime EntryDate { get; set; } = DateTime.Now;

        public DateTime? ExitDate { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal? TakeProfit { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal? StopLoss { get; set; }

        public int PipSize { get; set; }

        [Required]
        public Stock Stock { get; set; }
    }
}
