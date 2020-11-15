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
    public class CoalitionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CoalitionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Coalition>>> GetAll()
        {
            var coalitions = await _context.Coalitions.ToListAsync();
            return coalitions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Coalition>> Get(int id)
        {
            var coalition = await _context.Coalitions.FindAsync(id);
            if(coalition == null) {
                return NotFound();
            }

            return coalition;
        }

        [HttpPost]
        public async Task<ActionResult<Coalition>> Post(Coalition coalition)
        {
            await _context.Coalitions.AddAsync(coalition);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = coalition.Id }, coalition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Coalition coalition)
        {
            if (id != coalition.Id)
            {
                return BadRequest();
            }

            _context.Entry(coalition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CoalitionExists(id))
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
            var coalition = await _context.Coalitions.FindAsync(id);
            if (coalition == null)
            {
                return NotFound();
            }

            _context.Coalitions.Remove(coalition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CoalitionExists(int id) 
            => await _context.Coalitions.AnyAsync(p => p.Id == id);
    }
}