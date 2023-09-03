using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Nexus.Api.Domain.Entities
{
    [Table("File")]
    public class File
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }

        public string ProjectId { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }
    }
}
