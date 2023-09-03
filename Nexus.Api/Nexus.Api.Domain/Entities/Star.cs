using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    [Table("Star")]
    public class Star
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
