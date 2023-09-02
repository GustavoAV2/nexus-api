using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Api.Infrastructure
{
    public class TagDb : DbContext
    {
        public TagDb(DbContextOptions<TagDb> options)
       : base(options) { }

        public DbSet<Tag> Tag { get; set; }
        public DbSet<Tag> All => Set<Tag>();
    }
}
