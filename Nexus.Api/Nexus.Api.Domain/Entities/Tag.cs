using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    [Table("Tag")]
    public class Tag
    {
        public string Name { get; set; }
        public string Id { get; set; }

        [JsonIgnore]
        public virtual List<Project> Projects { get; set; }
    }
}
