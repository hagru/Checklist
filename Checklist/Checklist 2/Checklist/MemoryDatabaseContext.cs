using Checklist.Models;
using Microsoft.EntityFrameworkCore;

namespace Checklist
{
    public class MemoryDatabaseContext : DbContext
    {
        public MemoryDatabaseContext(DbContextOptions<MemoryDatabaseContext> opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CheckItems");
        }

        public DbSet<CheckItem> CheckItems { get; set; }
    }
}
