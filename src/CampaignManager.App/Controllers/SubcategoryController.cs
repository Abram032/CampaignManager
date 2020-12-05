using System.Threading.Tasks;
using CampaignManager.App.Data;
using CampaignManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CampaignManager.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SubcategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subcategory>>> GetAll()
        {
            var subcategories = await _context.Subcategories.ToListAsync();
            return subcategories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> Get(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if(subcategory == null) {
                return NotFound();
            }

            return subcategory;
        }

        [HttpPost]
        public async Task<ActionResult<Subcategory>> Post(Subcategory subcategory)
        {
            await _context.Subcategories.AddAsync(subcategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = subcategory.Id }, subcategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Subcategory subcategory)
        {
            if (id != subcategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await SubcategoryExists(id))
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
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> SubcategoryExists(int id) 
            => await _context.Subcategories.AnyAsync(p => p.Id == id);
    }
}