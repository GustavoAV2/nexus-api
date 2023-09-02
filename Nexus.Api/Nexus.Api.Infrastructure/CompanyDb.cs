using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;

namespace Nexus.Api.Infrastructure
{

    public class CompanyDb : DbContext
    {
        public CompanyDb(DbContextOptions<CompanyDb> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Company> All => Set<Company>();
    }
}
