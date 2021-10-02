using Checklist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.Interfaces
{
    interface ICheckItemRepository
    {
        Task<IReadOnlyCollection<CheckItem>> GetAll();
        Task<CheckItem> GetById(string id);
        Task<CheckItem> Create(CheckItem item);
        Task Delete();
    }
}
