using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Abstractions
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetByEmailAsync(string email);
    }
}
