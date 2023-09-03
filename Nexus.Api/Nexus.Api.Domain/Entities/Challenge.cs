using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    [Table("Challenge")]
    public class Challenge
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
    }
}
