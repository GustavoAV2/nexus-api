using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    public class UserRelation
    {
        public string Id { get; set; }
        public string FollowingUserId { get; set; }
        public string FollowedUserId { get; set; }
        [JsonIgnore]
        public virtual User FollowingUser { get; set; }
        [JsonIgnore]
        public virtual User FollowedUser { get; set; }
    }
}
