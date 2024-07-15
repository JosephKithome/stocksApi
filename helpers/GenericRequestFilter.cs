using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.helpers
{
    public class GenericRequestFilter
    {
        public string ? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
    }
}