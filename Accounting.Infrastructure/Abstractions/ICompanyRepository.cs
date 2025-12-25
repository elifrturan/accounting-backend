using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Abstractions
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
    }
}
