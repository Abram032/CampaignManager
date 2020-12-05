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
    public class FactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Faction>>> GetAll()
        {
            var factions = await _context.Factions.ToListAsync();
            return factions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Faction>> Get(int id)
        {
            var faction = await _context.Factions.FindAsync(id);
            if(faction == null) {
                return NotFound();
            }

            return faction;
        }

        [HttpPost]
        public async Task<ActionResult<Faction>> Post(Faction faction)
        {
            await _context.Factions.AddAsync(faction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = faction.Id }, faction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Faction faction)
        {
            if (id != faction.Id)
            {
                return BadRequest();
            }

            _context.Entry(faction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await FactionExists(id))
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
            var faction = await _context.Factions.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }

            _context.Factions.Remove(faction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> FactionExists(int id) 
            => await _context.Factions.AnyAsync(p => p.Id == id);
    }
}