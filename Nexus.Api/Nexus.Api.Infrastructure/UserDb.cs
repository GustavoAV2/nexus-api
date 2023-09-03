using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;

namespace Nexus.Api.Infrastructure
{
    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Projects).WithOne(u => u.User);
            modelBuilder.Entity<User>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().HasMany(s => s.Stars).WithOne(u => u.User);
            modelBuilder.Entity<User>().HasMany(u => u.Skills).WithOne(u => u.User);

            modelBuilder.Entity<Project>().HasKey(t => t.Id);
            modelBuilder.Entity<Project>().HasMany(c => c.Tags);
            modelBuilder.Entity<Project>().HasMany(s => s.Stars);
            modelBuilder.Entity<Project>().HasMany(s => s.Files).WithOne(f => f.Project);
            modelBuilder.Entity<Project>().HasMany(p => p.ProjectSkills).WithOne(p => p.Project);

            modelBuilder.Entity<UserSkillProject>().HasKey(us => us.Id);

            modelBuilder.Entity<Skill>().HasKey(s => s.Id);
            modelBuilder.Entity<Challenge>().HasKey(ch => ch.Id);
            
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Company>().HasMany(c => c.Challenges);

            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Star>().HasKey(t => t.Id);
        }

        public DbSet<User> User { get; set; }
        public DbSet<User> All => Set<User>();
    }
}
