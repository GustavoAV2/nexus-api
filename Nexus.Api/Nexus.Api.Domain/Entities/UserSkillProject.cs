using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    [Table("UserSkillProject")]
    public class UserSkillProject
    {
        public string Id { get; set; }
        public string SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public string ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
