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
    public class MissionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MissionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mission>>> GetAll()
        {
            var missions = await _context.Missions.ToListAsync();
            return missions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> Get(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if(mission == null) {
                return NotFound();
            }

            return mission;
        }

        [HttpPost]
        public async Task<ActionResult<Mission>> Post(Mission mission)
        {
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = mission.Id }, mission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Mission mission)
        {
            if (id != mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await MissionExists(id))
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
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> MissionExists(int id) 
            => await _context.Missions.AnyAsync(p => p.Id == id);
    }
}