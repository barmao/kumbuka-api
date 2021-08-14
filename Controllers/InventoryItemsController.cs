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
        //private readonly InventoryItemContext _context;
        private readonly InventoryItemsService _inventoryItemsService;

        public InventoryItemsController(InventoryItemsService inventoryItem)
        {
            //_context = context;
            _inventoryItemsService = inventoryItem;
        }


        [HttpGet]
        public ActionResult<List<InventoryItem>> Get() => _inventoryItemsService.Get();

        // GET: api/InventoryItems
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

        [HttpPost]
        public ActionResult<InventoryItem> Create(InventoryItem item)
        {
            _inventoryItemsService.Create(item);

            return CreatedAtRoute("GetBook", new { id = item.Id.ToString() }, item);
        }

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

        //// GET: api/InventoryItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<InventoryItem>> GetInventoryItem(long id)
        //{
        //    var inventoryItem = await _context.InventoryItems.FindAsync(id);

        //    if (inventoryItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return inventoryItem;
        //}

        //// PUT: api/InventoryItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInventoryItem(long id, InventoryItem inventoryItem)
        //{
        //    if (id != inventoryItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(inventoryItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InventoryItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/InventoryItems
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        //{
        //    _context.InventoryItems.Add(inventoryItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        //    return CreatedAtAction(nameof(GetInventoryItem), new { id = inventoryItem.Id }, inventoryItem);
        //}

        //// DELETE: api/InventoryItems/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteInventoryItem(long id)
        //{
        //    var inventoryItem = await _context.InventoryItems.FindAsync(id);
        //    if (inventoryItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.InventoryItems.Remove(inventoryItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool InventoryItemExists(long id)
        //{
        //    return _context.InventoryItems.Any(e => e.Id == id);
        //}
    }
}
