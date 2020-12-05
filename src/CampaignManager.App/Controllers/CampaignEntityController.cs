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
    public class CampaignEntityController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CampaignEntityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CampaignEntity>>> GetAll()
        {
            var entities = await _context.CampaignEntities.ToListAsync();
            return entities;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignEntity>> Get(int id)
        {
            var entity = await _context.CampaignEntities.FindAsync(id);
            if(entity == null) {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<CampaignEntity>> Post(CampaignEntity entity)
        {
            await _context.CampaignEntities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CampaignEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await CampaignEntityExists(id))
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
            var entity = await _context.CampaignEntities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.CampaignEntities.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CampaignEntityExists(int id) 
            => await _context.CampaignEntities.AnyAsync(p => p.Id == id);
    }
}