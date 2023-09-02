using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Infrastructure
{
    public class ChallengeDb : DbContext
    {
        public ChallengeDb(DbContextOptions<ChallengeDb> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Challenge> Challenge { get; set; }
        public DbSet<Challenge> All => Set<Challenge>();
    }
}
