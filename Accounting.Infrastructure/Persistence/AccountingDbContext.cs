using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infrastructure.Persistence
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options) { }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Company> Companies => Set<Company>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.Email)
                    .IsUnique();

                entity.Property(x => x.FullName)
                    .IsRequired();

                entity.Property(x => x.Email)
                    .IsRequired();

                entity.HasOne(x => x.Company)
                    .WithMany(c => c.Users)
                    .HasForeignKey(x => x.CompanyId);

                entity.HasOne(x => x.Role)
                    .WithMany()
                    .HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).IsRequired();
            });

            RoleSeed.Seed(modelBuilder);
        }
    }
}
