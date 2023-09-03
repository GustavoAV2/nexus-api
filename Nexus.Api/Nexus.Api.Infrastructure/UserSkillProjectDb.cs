using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;

namespace Nexus.Api.Infrastructure
{

    public class UserSkillProjectDb : DbContext
    {
        public UserSkillProjectDb(DbContextOptions<UserSkillProjectDb> options)
        : base(options) { }

        public DbSet<UserSkillProject> UserSkillProject { get; set; }
        public DbSet<UserSkillProject> All => Set<UserSkillProject>();
    }
}
