using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
