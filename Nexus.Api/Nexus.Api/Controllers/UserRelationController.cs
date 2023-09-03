using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRelationController : ControllerBase
{
    private readonly ILogger<UserRelationController> _logger;
    private readonly IUserRelationService _userRelationService;

    public UserRelationController(ILogger<UserRelationController> logger, IUserRelationService UserRelationService)
    {
        _logger = logger;
        _userRelationService = UserRelationService;
    }

    [HttpGet(Name = "GetUserRelations")]
    public async Task<List<UserRelation>> GetAllUserRelations()
    {
        return await _userRelationService.GetAllUserRelations();
    }

    [HttpPost(Name = "PostUserRelation")]
    public async Task<UserRelation> CreateUserRelation(UserRelation UserRelation)
    {
        return await _userRelationService.CreateUserRelation(UserRelation);
    }
}
