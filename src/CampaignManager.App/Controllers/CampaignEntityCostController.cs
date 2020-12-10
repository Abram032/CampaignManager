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
    public class CampaignEntityCostController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CampaignEntityCostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CampaignEntityCostDTO>>> GetAll(int campaignId)
        {
            var entityCosts = _context.CampaignEntityCosts
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .AsQueryable();

            if(campaignId != 0) {
                entityCosts = entityCosts.Where(p => p.Campaign.Id == campaignId);
            }

            var result = await entityCosts.ToListAsync();

            return result.Select(p => new CampaignEntityCostDTO {
                Id = p.Id,
                CampaignId = p.Campaign.Id,
                EntityId = p.Entity.Id,
                Cost = p.Cost
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignEntityCostDTO>> Get(int id)
        {
            var entityCost = await _context.CampaignEntityCosts
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(entityCost == null) {
                return NotFound();
            }

            return new CampaignEntityCostDTO {
                Id = entityCost.Id,
                CampaignId = entityCost.Campaign.Id,
                EntityId = entityCost.Entity.Id,
                Cost = entityCost.Cost
            };
        }

        [HttpPost]
        public async Task<ActionResult<CampaignEntityCostDTO>> Post(CampaignEntityCostDTO entityCost)
        {
            var _entityCost = new CampaignEntityCost {
                Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entityCost.CampaignId),
                Entity = await _context.Entities.FirstOrDefaultAsync(p => p.Id == entityCost.EntityId),
                Cost = entityCost.Cost
            };

            await _context.CampaignEntityCosts.AddAsync(_entityCost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _entityCost.Id }, entityCost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CampaignEntityCostDTO entityCost)
        {
            if (id != entityCost.Id)
            {
                return BadRequest();
            }

            var _entityCost = await _context.CampaignEntityCosts
                .Include(p => p.Campaign)
                .Include(p => p.Entity)
                .FirstOrDefaultAsync(p => p.Id == id);

            _entityCost.Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == entityCost.CampaignId);
            _entityCost.Entity = await _context.Entities.FirstOrDefaultAsync(p => p.Id == entityCost.EntityId);
            _entityCost.Cost = entityCost.Cost;
            
            _context.CampaignEntityCosts.Update(_entityCost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entityCost = await _context.CampaignEntityCosts.FindAsync(id);
            if (entityCost == null)
            {
                return NotFound();
            }

            _context.CampaignEntityCosts.Remove(entityCost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}