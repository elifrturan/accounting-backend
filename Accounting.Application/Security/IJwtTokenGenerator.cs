using Accounting.Application.DTOs;
using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Security
{
    public interface IJwtTokenGenerator
    {
        LoginResponse Generate(User user);
    }
}
