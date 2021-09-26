using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.Models
{
    public class CheckItem
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }
    }
}
