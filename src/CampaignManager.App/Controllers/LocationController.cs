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
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAll()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> Get(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if(location == null) {
                return NotFound();
            }

            return location;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Post(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await LocationExists(id))
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
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> LocationExists(int id) 
            => await _context.Locations.AnyAsync(p => p.Id == id);
    }
}