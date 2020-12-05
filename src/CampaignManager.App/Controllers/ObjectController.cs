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
    public class ObjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ObjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ObjectDTO>>> GetAll()
        {
            var objects = await _context.Objects
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .ToListAsync();

            return objects.Select(p => new ObjectDTO {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.Category.Id,
                SubcategoryId = p.Subcategory.Id,
                Type = p.Type,
                DefaultCost = p.DefaultCost
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectDTO>> Get(int id)
        {
            var @object = await _context.Objects
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if(@object == null) {
                return NotFound();
            }

            return new ObjectDTO {
                Id = @object.Id,
                Name = @object.Name,
                CategoryId = @object.Category.Id,
                SubcategoryId = @object.Subcategory.Id,
                Type = @object.Type,
                DefaultCost = @object.DefaultCost
            };
        }

        [HttpPost]
        public async Task<ActionResult<ObjectDTO>> Post(ObjectDTO @object)
        {
            var _object = new Object {
                Name = @object.Name,
                Category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == @object.CategoryId),
                Subcategory = await _context.Subcategories.FirstOrDefaultAsync(p => p.Id == @object.SubcategoryId),
                Type = @object.Type,
                DefaultCost = @object.DefaultCost
            };

            await _context.Objects.AddAsync(_object);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = _object.Id }, _object);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ObjectDTO @object)
        {
            if (id != @object.Id)
            {
                return BadRequest();
            }

            var _object = await _context.Objects
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .FirstOrDefaultAsync(p => p.Id == id);

            _object.Name = @object.Name;
            _object.Category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == @object.CategoryId);
            _object.Subcategory = await _context.Subcategories.FirstOrDefaultAsync(p => p.Id == @object.SubcategoryId);
            _object.Type = @object.Type;
            _object.DefaultCost = @object.DefaultCost;
            
            _context.Objects.Update(_object);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var @object = await _context.Objects.FindAsync(id);
            if (@object == null)
            {
                return NotFound();
            }

            _context.Objects.Remove(@object);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> ObjectExists(int id) 
            => await _context.Objects.AnyAsync(p => p.Id == id);
    }
}