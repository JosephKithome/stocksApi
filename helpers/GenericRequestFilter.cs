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
    }
}