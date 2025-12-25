using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.DTOs
{
    public class RegisterRequest
    {
        public string CompanyName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool AcceptTerms { get; set; }
    }
}
