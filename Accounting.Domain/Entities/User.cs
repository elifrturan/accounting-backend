using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public string PasswordHash { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
