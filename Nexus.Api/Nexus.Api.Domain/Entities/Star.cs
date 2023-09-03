using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    public class Star
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string UserId { get; set; }
    }
}
