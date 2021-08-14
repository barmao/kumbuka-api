using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kumbuka_api.Models;
using kumbuka_api.Services;

namespace kumbuka_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly InventoryItemsService _inventoryItemsService;

        public InventoryItemsController(InventoryItemsService inventoryItem)
        {
            _inventoryItemsService = inventoryItem;
        }

        // GET: api/InventoryItems
        [HttpGet]
        public ActionResult<List<InventoryItem>> Get() => _inventoryItemsService.Get();

        
        //// GET: api/InventoryItems/5
        [HttpGet("{id:length(24)}", Name = "GetInventoryItems")]
        public ActionResult<InventoryItem> Get(string id)
        {
            var item = _inventoryItemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        //// POST: api/InventoryItems
        [HttpPost]
        public ActionResult<InventoryItem> Create(InventoryItem item)
        {
            _inventoryItemsService.Create(item);

            return CreatedAtRoute("GetBook", new { id = item.Id.ToString() }, item);
        }

        //// PUT: api/InventoryItems/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, InventoryItem itemIn)
        {
            var item = _inventoryItemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _inventoryItemsService.Update(id, itemIn);

            return NoContent();
        }

        //// DELETE: api/InventoryItems/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = _inventoryItemsService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _inventoryItemsService.Remove(item.Id);

            return NoContent();
        }
    }
}
