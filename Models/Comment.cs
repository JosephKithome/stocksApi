using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int StockId { get; set; }
        //public DateTime CreatedOn { get; set; } = DateTime.Now;

        // Navigation property
        private Stock? Stock { get; set; }
    }
}