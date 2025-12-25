using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infrastructure.Persistence
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Üye"
                }
            );
        }
    }
}
