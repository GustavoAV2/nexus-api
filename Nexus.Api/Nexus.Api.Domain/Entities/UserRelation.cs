using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Domain.Entities
{
    public class UserRelation
    {
        public string Id { get; set; }
        public string FollowingUserId { get; set; }
        public string FollowedUserId { get; set; }
        public virtual User FollowingUser { get; set; }
        public virtual User FollowedUser { get; set; }
    }
}
