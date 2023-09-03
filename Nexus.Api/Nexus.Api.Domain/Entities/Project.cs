using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Api.Domain.Entities
{
    [Table("Project")]
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isPublic { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<UserSkillProject> ProjectSkills { get; set; }
    }
}
