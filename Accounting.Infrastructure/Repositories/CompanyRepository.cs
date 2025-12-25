using Accounting.Application.Abstractions;
using Accounting.Domain.Entities;
using Accounting.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AccountingDbContext _context;

        public CompanyRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            await _context.AddAsync(company);
        }
    }
}
