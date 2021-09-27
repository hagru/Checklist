using Checklist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist
{
    public class MemoryDatabaseContext : DbContext
    {
        public DbSet<CheckItem> CheckItems { get; set; }
    }
}
