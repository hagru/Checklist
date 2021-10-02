using Checklist.Interfaces;
using Checklist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.Repositories
{
    public class CheckItemRepository : ICheckItemRepository
    {
        private MemoryDatabaseContext Context { get; set; }

        public CheckItemRepository(MemoryDatabaseContext context)
        {
            Context = context;
        }

        public async Task<CheckItem> Create(CheckItem item)
        {
            Context.CheckItems.Add(item);
            return item;
           // return GetById(item.Id);
        }

        public void Delete(string id)
        {
            var item = Context.CheckItems.Where(e => e.Id == id).FirstOrDefault();
            Context.CheckItems.Remove(item);
        }

        public async Task<IReadOnlyCollection<CheckItem>> GetAll()
        {
            return Context.CheckItems.ToList();
        }

        public async Task<CheckItem> GetById(string id)
            => Context.CheckItems.Where(e => e.Id == id).FirstOrDefault();
    }
}
