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

            modelBuilder.Entity<Project>().HasKey(t => t.Id);

            modelBuilder.Entity<Company>().HasKey(t => t.Id);
            modelBuilder.Entity<Company>().HasMany(c => c.Challenges);

            modelBuilder.Entity<Challenge>().HasKey(t => t.Id);

        }

        public DbSet<User> User { get; set; }
        public DbSet<User> All => Set<User>();
    }
}
