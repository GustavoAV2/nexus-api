using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    public class Skill
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
