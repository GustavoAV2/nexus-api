using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Nexus.Api.Domain.Entities
{
    [Table("Company")]
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Challenge> Challenges { get; set; }
    }
}
