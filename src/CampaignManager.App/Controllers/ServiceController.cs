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
    public class ServiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetAll()
        {
            var services = await _context.Services.ToListAsync();
            return services;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if(service == null) {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ServiceExists(id))
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
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ServiceExists(int id) 
            => await _context.Services.AnyAsync(p => p.Id == id);
    }
}