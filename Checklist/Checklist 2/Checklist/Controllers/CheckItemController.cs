using Checklist.Interfaces;
using Checklist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Checklist.Controllers
{
    [ApiController]
    [Route("check-items")]
    public class CheckItemController : Controller
    {
        private ICheckItemRepository Repository { get; }

        public CheckItemController(ICheckItemRepository repository)
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
            if (item == null) return NotFound($"Could not find check item with ID '{id}'");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CheckItem>> Create(CheckItem item)
        {
            var created = await Repository.Create(item);
            if (created == null) return Conflict("Could not persist resource.");
            return Ok(created);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            Repository.Delete(id);
            return Ok();
        }
    }
}
