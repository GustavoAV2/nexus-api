using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarController
    {
        private readonly ILogger<StarController> _logger;
        private readonly IStarService _starService;

        public StarController(ILogger<StarController> logger, IStarService starService)
        {
            _logger = logger;
            _starService = starService;
        }

        [HttpGet(Name = "GetStars")]
        public async Task<List<Star>> GetAllStars()
        {
            return await _starService.GetAllStars();
        }


        [HttpPost(Name = "PostStar")]
        public async Task<Star> CreateStars(Star star)
        {
            return await _starService.CreateStar(star);
        }
    }
}
