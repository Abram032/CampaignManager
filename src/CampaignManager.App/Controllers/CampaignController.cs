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
    public class CampaignController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CampaignController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Campaign>>> GetAll()
        {
            var campaigns = await _context.Campaigns.ToListAsync();
            return campaigns;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign>> Get(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            if(campaign == null) {
                return NotFound();
            }

            return campaign;
        }

        [HttpPost]
        public async Task<ActionResult<Campaign>> Post(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = campaign.Id }, campaign);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return BadRequest();
            }

            _context.Entry(campaign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CampaignExists(id))
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
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CampaignExists(int id) 
            => await _context.Campaigns.AnyAsync(p => p.Id == id);
    }
}