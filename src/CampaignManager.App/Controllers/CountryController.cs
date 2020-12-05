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
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAll()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if(country == null) {
                return NotFound();
            }

            return country;
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CountryExists(id))
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
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CountryExists(int id) 
            => await _context.Countries.AnyAsync(p => p.Id == id);
    }
}