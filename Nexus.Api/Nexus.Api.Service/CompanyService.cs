
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexus.Api.Service
{
    public class CompanyService : ICompanyService
    {

        private readonly ILogger<CompanyService> _logger;
        private readonly CompanyDb _companyDb;
        private IConfiguration _configuration { get; }

        public CompanyService(ILogger<CompanyService> logger, IConfiguration configuration, CompanyDb userDb)
        {
            _logger = logger;
            _companyDb = userDb;
            _configuration = configuration;
        }

        public async Task<Company> CreateCompany(Company inputCompany)
        {
            var newCompany = new Company
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputCompany.Name,
            };

            _companyDb.All.Add(newCompany);
            await _companyDb.SaveChangesAsync();
            return newCompany;
        }
    }
}
