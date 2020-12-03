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
    public class ObjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ObjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Object>>> GetAll()
        {
            var objects = await _context.Objects
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .ToListAsync();
            return objects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> Get(int id)
        {
            var @object = await _context.Objects.FindAsync(id);
            if(@object == null) {
                return NotFound();
            }

            return @object;
        }

        [HttpPost]
        public async Task<ActionResult<Object>> Post(Object @object)
        {
            await _context.Objects.AddAsync(@object);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = @object.Id }, @object);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Object @object)
        {
            if (id != @object.Id)
            {
                return BadRequest();
            }

            _context.Entry(@object).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ObjectExists(id))
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
            var @object = await _context.Objects.FindAsync(id);
            if (@object == null)
            {
                return NotFound();
            }

            _context.Objects.Remove(@object);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ObjectExists(int id) 
            => await _context.Objects.AnyAsync(p => p.Id == id);
    }
}