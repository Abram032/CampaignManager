using System.Threading.Tasks;
using CampaignManager.App.Data;
using CampaignManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.App.Models;

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
        public async Task<ActionResult<List<FactionDTO>>> GetAll(int campaignId)
        {
            var factions = _context.Factions
                .Include(p => p.Campaign)
                .Include(p => p.Country)
                .Include(p => p.Coalition)
                .AsQueryable();

            if(campaignId != 0) {
                factions = factions.Where(p => p.Campaign.Id == campaignId);
            }

            var result = await factions.ToListAsync();

            return result.Select(p => new FactionDTO {
                Id = p.Id,
                Name = p.Name,
                CampaignId = p.Campaign.Id,
                CountryId = p.Country.Id,
                CoalitionId = p.Coalition.Id,
                Budget = p.Budget
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FactionDTO>> Get(int id)
        {
            var faction = await _context.Factions
                .Include(p => p.Campaign)
                .Include(p => p.Country)
                .Include(p => p.Coalition)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(faction == null) {
                return NotFound();
            }

            return new FactionDTO {
                Id = faction.Id,
                Name = faction.Name,
                CampaignId = faction.Campaign.Id,
                CountryId = faction.Country.Id,
                CoalitionId = faction.Coalition.Id,
                Budget = faction.Budget
            };
        }

        [HttpPost]
        public async Task<ActionResult<FactionDTO>> Post(FactionDTO faction)
        {
            var _faction = new Faction {
                Name = faction.Name,
                Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == faction.CampaignId),
                Coalition = await _context.Coalitions.FirstOrDefaultAsync(p => p.Id == faction.CoalitionId),
                Country = await _context.Countries.FirstOrDefaultAsync(p => p.Id == faction.CountryId),
                Budget = faction.Budget
            };

            await _context.Factions.AddAsync(_faction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _faction.Id }, faction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FactionDTO faction)
        {
            if (id != faction.Id)
            {
                return BadRequest();
            }

            var _faction = await _context.Factions
                .Include(p => p.Campaign)
                .Include(p => p.Country)
                .Include(p => p.Coalition)
                .FirstOrDefaultAsync(p => p.Id == id);

            _faction.Name = faction.Name;
            _faction.Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == faction.CampaignId);
            _faction.Coalition = await _context.Coalitions.FirstOrDefaultAsync(p => p.Id == faction.CoalitionId);
            _faction.Country = await _context.Countries.FirstOrDefaultAsync(p => p.Id == faction.CountryId);
            _faction.Budget = faction.Budget;
            
            _context.Factions.Update(_faction);
            await _context.SaveChangesAsync();

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
    }
}