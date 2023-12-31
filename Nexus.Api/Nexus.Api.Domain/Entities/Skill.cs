﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Nexus.Api.Domain.Entities
{
    [Table("Skill")]
    public class Skill
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual List<Endorsement> Endorsements { get; set; }
    }
}
