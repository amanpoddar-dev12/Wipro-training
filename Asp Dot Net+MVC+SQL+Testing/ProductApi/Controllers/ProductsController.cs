using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db) => _db = db;

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var items = await _db.Products.AsNoTracking().ToListAsync();
            return Ok(items);
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var item = await _db.Products.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product input)
        {
            _db.Products.Add(input);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        // PUT: api/products/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Product input)
        {
            if (id != input.Id) return BadRequest("ID mismatch.");

            var exists = await _db.Products.AnyAsync(p => p.Id == id);
            if (!exists) return NotFound();

            _db.Entry(input).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Products.FindAsync(id);
            if (item == null) return NotFound();

            _db.Products.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
