using Checklist.Interfaces;
using Checklist.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Repositories
{
    public class CheckItemRepository : ICheckItemRepository
    {
        private MemoryDatabaseContext Context { get; }

        public CheckItemRepository(MemoryDatabaseContext context)
        {
            Context = context;
        }

        public async Task<CheckItem> Create(CheckItem item)
        {
            await Context.CheckItems.AddAsync(item);
            await Context.SaveChangesAsync();
            return await GetById(item.Id);
            
            // return GetById(item.Id);
        }

        public async Task Delete(string id)
        {
            var item = await Context.CheckItems.FirstOrDefaultAsync(e => e.Id == id);
            Context.CheckItems.Remove(item);
            await Context.SaveChangesAsync();

        }

        public async Task<IReadOnlyCollection<CheckItem>> GetAll()
        {
            return await Context.CheckItems.Where(a => true).ToListAsync();
        }

        public async Task<CheckItem> GetById(string id)
        {
            return await Context.CheckItems.FirstOrDefaultAsync(e => e.Id == id);
        }
            
    }
}
