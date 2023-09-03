using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;

namespace Nexus.Api.Infrastructure
{

    public class SkillDb : DbContext
    {
        public SkillDb(DbContextOptions<SkillDb> options)
        : base(options) { }

        public DbSet<Skill> Project { get; set; }
        public DbSet<Skill> All => Set<Skill>();
    }
}
