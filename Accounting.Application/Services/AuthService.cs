using Accounting.Application.Abstractions;
using Accounting.Application.DTOs;
using Accounting.Application.Security;
using Accounting.Domain.Entities;
using Accounting.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AccountingDbContext _context;

        public AuthService(IUserRepository userRepository, ICompanyRepository companyRepository, IRoleRepository roleRepository, AccountingDbContext context, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _roleRepository = roleRepository;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.EmailExistsAsync(request.Email))
                throw new Exception("Bu e-posta zaten kayıtlı");

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = request.CompanyName
                };

                await _companyRepository.AddAsync(company);

                var adminRole = await _roleRepository.GetByNameAsync("Admin");
                if (adminRole == null)
                    throw new Exception("Admin rolü bulunamadı");

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = request.FullName,
                    Email = request.Email,
                    PasswordHash = _passwordHasher.Hash(request.Password),
                    CompanyId = company.Id,
                    RoleId = adminRole.Id,
                    CreatedAt = DateTime.UtcNow,
                };

                await _userRepository.AddAsync(user);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            } catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
