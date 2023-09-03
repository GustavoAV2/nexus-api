using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompany(Company inputUser);
        Task<List<Company>> GetAllCompanies();
    }
}
