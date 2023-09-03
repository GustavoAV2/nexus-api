﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Api.Domain.Entities
{
    [Table("Skill")]
    public class Skill
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
