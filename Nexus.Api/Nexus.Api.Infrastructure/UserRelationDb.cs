using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Infrastructure
{
    public class UserRelationDb : DbContext
    {
        public UserRelationDb(DbContextOptions<UserRelationDb> options)
        : base(options) { }

        public DbSet<UserRelation> UserRelation { get; set; }
        public DbSet<UserRelation> All => Set<UserRelation>();
    }
}
