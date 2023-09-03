using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nexus.Api.Domain.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkills();

        Task<Skill> CreateSkill(Skill skill);

        Task<UserSkillProject> CreateUserSkillProject(UserSkillProject inputSkill);
    }
}
