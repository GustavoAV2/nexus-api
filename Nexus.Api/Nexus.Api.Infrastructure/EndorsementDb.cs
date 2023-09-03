using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Infrastructure
{
    public class EndorsementDb : DbContext
    {
        public EndorsementDb(DbContextOptions<EndorsementDb> options)
        : base(options) { }

        public DbSet<Endorsement> Endorsement { get; set; }
        public DbSet<Endorsement> All => Set<Endorsement>();
    }
}
