using System.Threading.Tasks;
using CampaignManager.App.Data;
using CampaignManager.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using CampaignManager.Models;

namespace CampaignManager.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SubcategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubcategoryDTO>>> GetAll()
        {
            var subcategories = await _context.Subcategories
                .ToListAsync();

            return subcategories.Select(p => new SubcategoryDTO {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubcategoryDTO>> Get(int id)
        {
            var entity = await _context.Entities
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(entity == null) {
                return NotFound();
            }

            return new SubcategoryDTO {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        [HttpPost]
        public async Task<ActionResult<SubcategoryDTO>> Post(SubcategoryDTO subcategory)
        {
            var _subcategory = new Subcategory {
                Name = subcategory.Name
            };

            await _context.Subcategories.AddAsync(_subcategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _subcategory.Id }, subcategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SubcategoryDTO subcategory)
        {
            if (id != subcategory.Id)
            {
                return BadRequest();
            }

            var _subcategory = await _context.Subcategories
                .FirstOrDefaultAsync(p => p.Id == id);

            _subcategory.Name = subcategory.Name;
            
            _context.Subcategories.Update(_subcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}