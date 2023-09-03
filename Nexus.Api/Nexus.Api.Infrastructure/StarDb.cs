using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Infrastructure
{
    public class StarDb : DbContext
    {
        public StarDb(DbContextOptions<StarDb> options)
      : base(options) { }

        public DbSet<Star> Star { get; set; }
        public DbSet<Star> All => Set<Star>();
    }
}
