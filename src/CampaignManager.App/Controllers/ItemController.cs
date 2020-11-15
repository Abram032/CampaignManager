using System.Threading.Tasks;
using CampaignManager.App.Data;
using CampaignManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace CampaignManager.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAll()
        {
            var items = await _context.Items.ToListAsync();
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null) {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ItemExists(id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ItemExists(int id) 
            => await _context.Items.AnyAsync(p => p.Id == id);
    }
}