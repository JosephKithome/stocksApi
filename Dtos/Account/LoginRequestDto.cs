using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}