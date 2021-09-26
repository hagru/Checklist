using Checklist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.Controllers
{
    [ApiController]
    [Route("checklist-items")]
    public class ChecklistItemController : Controller
    {
        private static List<CheckItem> Checklist = new List<CheckItem>
        {
            new CheckItem
            {
                Id = "0",
                Owner = "Christian",
                Content = "Støvsuge"
            },

            new CheckItem
            {
                Id = "1",
                Owner = "Christian",
                Content = "Støvsuge"
            },

            new CheckItem
            {
                Id = "2",
                Owner = "Christian",
                Content = "Støvsuge"
            },

            new CheckItem
            {
                Id = "3",
                Owner = "Christian",
                Content = "Støvsuge"
            }
        };

        [HttpGet]
        public IEnumerable<CheckItem> Get()
        {
            return Checklist;
        }

        [HttpGet("{id}")]
        public ActionResult<CheckItem> GetById(string id)
        {
            var item = Checklist.Where(e => e.Id == id).FirstOrDefault();
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<CheckItem> Create(CheckItem item)
        {
            Checklist.Add(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var item = Checklist.Where(e => e.Id == id).FirstOrDefault();
            Checklist.Remove(item);
            return Ok();
        }
    }
}
