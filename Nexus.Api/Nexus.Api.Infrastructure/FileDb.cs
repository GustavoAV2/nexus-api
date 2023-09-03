using Microsoft.EntityFrameworkCore;
using Nexus.Api.Domain.Entities;


namespace Nexus.Api.Infrastructure
{
    public class FileDb : DbContext
    {
        public FileDb(DbContextOptions<FileDb> options)
        : base(options) { }

        public DbSet<File> File { get; set; }
        public DbSet<File> All => Set<File>();
    }
}
