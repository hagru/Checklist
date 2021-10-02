using Checklist.Interfaces;
using Checklist.Models;
using Checklist.Repositories;
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
        private ICheckItemRepository Repository { get; }

        public ChecklistItemController(ICheckItemRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<CheckItem>> Get()
        {
            return Ok(await Repository.GetAll());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckItem>> GetById(string id)
        {
            var item = await Repository.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CheckItem>> Create(CheckItem item)
        {
            return Ok(await Repository.Create(item));

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            Repository.Delete(id);
            return Ok();
        }
    }
}
