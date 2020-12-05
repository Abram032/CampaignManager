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
    public class EntityController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EntityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntityDTO>>> GetAll()
        {
            var entities = await _context.Entities
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .ToListAsync();

            return entities.Select(p => new EntityDTO {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.Category.Id,
                SubcategoryId = p.Subcategory.Id,
                Type = p.Type,
                DefaultCost = p.DefaultCost
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntityDTO>> Get(int id)
        {
            var entity = await _context.Entities
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(entity == null) {
                return NotFound();
            }

            return new EntityDTO {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.Category.Id,
                SubcategoryId = entity.Subcategory.Id,
                Type = entity.Type,
                DefaultCost = entity.DefaultCost
            };
        }

        [HttpPost]
        public async Task<ActionResult<EntityDTO>> Post(EntityDTO entity)
        {
            var _entity = new Entity {
                Name = entity.Name,
                Category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == entity.CategoryId),
                Subcategory = await _context.Subcategories.FirstOrDefaultAsync(p => p.Id == entity.SubcategoryId),
                Type = entity.Type,
                DefaultCost = entity.DefaultCost
            };

            await _context.Entities.AddAsync(_entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EntityDTO entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var _entity = await _context.Entities
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .FirstOrDefaultAsync(p => p.Id == id);

            _entity.Name = entity.Name;
            _entity.Category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == entity.CategoryId);
            _entity.Subcategory = await _context.Subcategories.FirstOrDefaultAsync(p => p.Id == entity.SubcategoryId);
            _entity.Type = entity.Type;
            _entity.DefaultCost = entity.DefaultCost;
            
            _context.Entities.Update(_entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}