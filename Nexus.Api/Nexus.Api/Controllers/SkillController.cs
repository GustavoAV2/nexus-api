using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ILogger<SkillController> _logger;
        private readonly ISkillService _skillService;

        public SkillController(ILogger<SkillController> logger, ISkillService skillService)
        {
            _logger = logger;
            _skillService = skillService;
        }

        [HttpGet(Name = "GetSkills")]
        public async Task<List<Skill>> GetAllSkills()
        {
            return await _skillService.GetAllSkills();
        }

        [HttpPost(Name = "PostSkill")]
        public async Task<Skill> CreateSkill(Skill skill)
        {
            return await _skillService.CreateSkill(skill);
        }
    }
}