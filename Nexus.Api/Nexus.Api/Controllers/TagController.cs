using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagService _tagService;

        public TagController(ILogger<TagController> logger, ITagService tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        [HttpGet(Name = "GetTags")]
        public async Task<List<Tag>> GetAllTags()
        {
            return await _tagService.GetAllTags();
        }


        [HttpPost(Name = "PostTags")]
        public async Task<Tag> CreateChallenge(Tag tag)
        {
            return await _tagService.CreateTag(tag);
        }
    }
}
