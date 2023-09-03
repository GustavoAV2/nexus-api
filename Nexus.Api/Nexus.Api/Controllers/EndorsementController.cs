using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EndorsementController : ControllerBase
{
    private readonly ILogger<EndorsementController> _logger;
    private readonly IEndorsementService _endorsementService;

    public EndorsementController(ILogger<EndorsementController> logger, IEndorsementService EndorsementService)
    {
        _logger = logger;
        _endorsementService = EndorsementService;
    }

    [HttpGet(Name = "GetEndorsements")]
    public async Task<List<Endorsement>> GetAllEndorsements()
    {
        return await _endorsementService.GetAllEndorsements();
    }

    [HttpPost(Name = "PostEndorsement")]
    public async Task<Endorsement> CreateEndorsement(Endorsement Endorsement)
    {
        return await _endorsementService.CreateEndorsement(Endorsement);
    }
}
