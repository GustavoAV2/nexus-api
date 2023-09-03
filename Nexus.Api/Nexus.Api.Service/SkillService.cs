using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;
using Nexus.Api.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Api.Service
{
    public class SkillService : ISkillService
    {
        private readonly ILogger<SkillService> _logger;
        private readonly UserSkillProjectDb _userSkillProjectDb;
        private readonly SkillDb _skillDb;

        private IConfiguration _configuration { get; }
        public SkillService(ILogger<SkillService> logger, IConfiguration configuration, UserSkillProjectDb userSkillProjectDb, SkillDb skillDb)
        {
            _logger = logger;
            _configuration = configuration;
            _skillDb = skillDb;
            _userSkillProjectDb = userSkillProjectDb;
        }

        public async Task<Skill> CreateSkill(Skill inputSkill)
        {
            var newSkill = new Skill
            {
                Id = Guid.NewGuid().ToString(),
                Title = inputSkill.Title,
                UserId = inputSkill.UserId
            };

            _skillDb.All.Add(newSkill);
            await _skillDb.SaveChangesAsync();
            return newSkill;
        }

        public async Task<UserSkillProject> CreateUserSkillProject(UserSkillProject inputSkill)
        {
            var newSkill = new UserSkillProject
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = inputSkill.ProjectId,
                SkillId = inputSkill.SkillId
            };

            _userSkillProjectDb.All.Add(newSkill);
            await _userSkillProjectDb.SaveChangesAsync();
            return newSkill;
        }


        public async Task<Skill> GetSkillById(string id)
        {
            var foundSkill = await _skillDb.All.FindAsync(id);

            if (foundSkill == null)
            {
                throw new KeyNotFoundException();
            }

            return foundSkill;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            var foundSkill = await _skillDb.All.ToListAsync();
            return foundSkill;
        }
    }
}
