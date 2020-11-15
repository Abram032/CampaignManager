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
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> GetAll()
        {
            var statuses = await _context.Statuses.ToListAsync();
            return statuses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if(status == null) {
                return NotFound();
            }

            return status;
        }

        [HttpPost]
        public async Task<ActionResult<Status>> Post(Status status)
        {
            await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = status.Id }, status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await StatusExists(id))
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
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> StatusExists(int id) 
            => await _context.Statuses.AnyAsync(p => p.Id == id);
    }
}