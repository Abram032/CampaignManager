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
    public class CampaignEntityController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CampaignEntityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CampaignEntityDTO>>> GetAll(int locationId)
        {
            var entities = _context.CampaignEntities
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .Include(p => p.Location)
                .Include(p => p.Faction)
                .AsQueryable();

            if(locationId != 0) {
                entities = entities.Where(p => p.Location.Id == locationId);
            }

            var result = await entities.ToListAsync();

            return result.Select(p => new CampaignEntityDTO {
                Id = p.Id,
                CampaignId = p.Campaign.Id,
                EntityId = p.Entity.Id,
                LocationId = p.Location.Id,
                Status = p.Status,
                Count = p.Count
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignEntityDTO>> Get(int id)
        {
            var entity = await _context.CampaignEntities
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .Include(p => p.Location)
                .Include(p => p.Faction)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(entity == null) {
                return NotFound();
            }

            return new CampaignEntityDTO {
                Id = entity.Id,
                CampaignId = entity.Campaign.Id,
                EntityId = entity.Entity.Id,
                LocationId = entity.Location.Id,
                Status = entity.Status,
                Count = entity.Count
            };
        }

        [HttpPost]
        public async Task<ActionResult<CampaignEntityDTO>> Post(CampaignEntityDTO entity)
        {
            var faction = (await _context.Locations.Include(p => p.Faction).FirstOrDefaultAsync(p => p.Id == entity.LocationId)).Faction;
            var _entity = new CampaignEntity {
                Name = (await _context.Entities.FirstOrDefaultAsync(p => p.Id == entity.EntityId))?.Name,
                Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entity.CampaignId),
                Entity = await _context.Entities.FirstOrDefaultAsync(p => p.Id == entity.EntityId),
                Faction = faction,
                Location = await _context.Locations.FirstOrDefaultAsync(p => p.Id == entity.LocationId),
                AvailableAt = (await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entity.CampaignId)).StartDate,
                Count = entity.Count,
                Status = entity.Status
            };

            var unitCost = (await _context.CampaignEntityCosts
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .FirstOrDefaultAsync(p => p.Entity.Id == entity.EntityId && p.Campaign.Id == entity.CampaignId))?.Cost ?? 
                (await _context.Entities.FirstOrDefaultAsync(p => p.Id == entity.EntityId)).DefaultCost;

            if(unitCost * entity.Count > faction.Budget) {
                return BadRequest();
            }

            faction.Budget -= unitCost * entity.Count;

            await _context.CampaignEntities.AddAsync(_entity);
            _context.Factions.Update(faction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CampaignEntityDTO entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var _entity = await _context.CampaignEntities
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .Include(p => p.Location)
                .Include(p => p.Faction)
                .FirstOrDefaultAsync(p => p.Id == id);

            _entity.Name = (await _context.Entities.FirstOrDefaultAsync(p => p.Id == entity.Id))?.Name;
            _entity.Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entity.CampaignId);
            _entity.Entity = await _context.Entities.FirstOrDefaultAsync(p => p.Id == entity.EntityId);
            _entity.Faction = (await _context.Locations.Include(p => p.Faction).FirstOrDefaultAsync(p => p.Id == entity.LocationId)).Faction;
            _entity.Location = await _context.Locations.FirstOrDefaultAsync(p => p.Id == entity.LocationId);
            _entity.AvailableAt = (await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entity.CampaignId)).StartDate;
            _entity.Count = entity.Count;
            _entity.Status = entity.Status;
            
            _context.CampaignEntities.Update(_entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.CampaignEntities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.CampaignEntities.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}