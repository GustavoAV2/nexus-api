using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _companyService;

        public CompanyController(ILogger<CompanyController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<List<Company>> GetAllCompanies()
        {
            return await _companyService.GetAllCompanies();
        }


        [HttpPost(Name = "CreateCompany")]
        public async Task<Company> CreateCompany(Company company)
        {
            return await _companyService.CreateCompany(company);
        }
    }
}