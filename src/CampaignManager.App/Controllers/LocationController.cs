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
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationDTO>>> GetAll(int campaignId)
        {
            var locations = _context.Locations
                .Include(p => p.Campaign)
                .Include(p => p.Faction)
                .AsQueryable();

            if(campaignId != 0) {
                locations = locations.Where(p => p.Campaign.Id == campaignId);
            }

            var result = await locations.ToListAsync();

            return result.Select(p => new LocationDTO {
                Id = p.Id,
                Name = p.Name,
                CampaignId = p.Campaign.Id,
                Description = p.Description,
                FactionId = p.Faction.Id,
                Longitude = p.Longitude,
                Latitude = p.Latitude,
                Status = p.Status
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> Get(int id)
        {
            var location = await _context.Locations
                .Include(p => p.Campaign)
                .Include(p => p.Faction)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(location == null) {
                return NotFound();
            }

            return new LocationDTO {
                Id = location.Id,
                Name = location.Name,
                CampaignId = location.Campaign.Id,
                Description = location.Description,
                FactionId = location.Faction.Id,
                Longitude = location.Longitude,
                Latitude = location.Latitude,
                Status = location.Status
            };
        }

        [HttpPost]
        public async Task<ActionResult<LocationDTO>> Post(LocationDTO location)
        {
            var _location = new Location {
                Name = location.Name,
                Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == location.CampaignId),
                Faction = await _context.Factions.FirstOrDefaultAsync(p => p.Id == location.FactionId),
                Description = location.Description,
                Longitude = location.Longitude,
                Latitude = location.Latitude,
                Status = location.Status
            };

            await _context.Locations.AddAsync(_location);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _location.Id }, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LocationDTO location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            var _location = await _context.Locations
                .Include(p => p.Campaign)
                .Include(p => p.Faction)
                .FirstOrDefaultAsync(p => p.Id == id);

            _location.Name = location.Name;
            _location.Campaign = await _context.Campaigns.FirstOrDefaultAsync(p => p.Id == location.CampaignId);
            _location.Faction = await _context.Factions.FirstOrDefaultAsync(p => p.Id == location.FactionId);
            _location.Description = location.Description;
            _location.Longitude = location.Longitude;
            _location.Latitude = location.Latitude;
            _location.Status = location.Status;
            
            _context.Locations.Update(_location);
            await _context.SaveChangesAsync();

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
    }
}