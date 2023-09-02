using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Service;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
        private readonly ILogger<ChallengeController> _logger;
        private readonly IChallengeService _challengeService;

        public ChallengeController(ILogger<ChallengeController> logger, IChallengeService challengeService)
        {
            _logger = logger;
            _challengeService = challengeService;
        }

        [HttpGet(Name = "GetChallenges")]
        public async Task<List<Challenge>> GetAllChallenges()
        {
            return await _challengeService.GetAllChallenges();
        }


        [HttpPost(Name = "PostChallenge")]
        public async Task<Challenge> CreateChallenge(Challenge challenge)
        {
            return await _challengeService.CreateChallenge(challenge);
        }
    }
}