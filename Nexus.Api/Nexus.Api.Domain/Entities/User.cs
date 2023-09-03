using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Api.Domain.Entities
{
    [Table("User")]
    public partial class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
