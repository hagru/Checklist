using System.Collections.Generic;
using Checklist.Models;
using Microsoft.EntityFrameworkCore;

namespace Checklist
{
    public class MemoryDatabaseContext : DbContext
    {
        public MemoryDatabaseContext(DbContextOptions opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("CheckItems");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<CheckItem>().HasData(itemList);

        public DbSet<CheckItem> CheckItems { get; set; }
        
        private readonly IEnumerable<CheckItem> itemList = new List<CheckItem>
        {
            new()
            {
                Id = "0",
                Owner = "Tolli",
                Content = "Schpaell"
            },
            new()
            {
                Id = "1",
                Owner = "Wessel",
                Content = "Rydde"
            },
            new()
            {
                Id = "2",
                Owner = "Hagru",
                Content = "Vaske"
            },
            new()
            {
                Id = "3",
                Owner = "Christian",
                Content = "Støvsuge"
            }
        };
    }
}
