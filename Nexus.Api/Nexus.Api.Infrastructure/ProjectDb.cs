using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;

namespace Nexus.Api.Infrastructure
{

    public class ProjectDb : DbContext
    {
        public ProjectDb(DbContextOptions<ProjectDb> options)
        : base(options) { }

        public DbSet<Project> Project { get; set; }
        public DbSet<Project> All => Set<Project>();
    }
}
