using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.DTOs
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
    }
}
