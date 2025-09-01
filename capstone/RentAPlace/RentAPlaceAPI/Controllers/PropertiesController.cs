using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPlaceAPI.Data;
using RentAPlaceAPI.Models;
using System.Security.Claims;

namespace RentAPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Owner,Admin")] // Owners manage their own, Admin can manage all
    public class PropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/properties
        [HttpGet]
        [AllowAnonymous] // anyone can view properties
        public async Task<IActionResult> GetProperties()
        {
            var props = await _context.Properties.Include(p => p.Owner).ToListAsync();
            return Ok(props);
        }

        // GET: api/properties/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _context.Properties.Include(p => p.Owner).FirstOrDefaultAsync(p => p.PropertyId == id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        // POST: api/properties
        [HttpPost]
        public async Task<IActionResult> AddProperty(Property property)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            property.OwnerId = userId;

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return Ok(property);
        }

        // PUT: api/properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property updated)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return NotFound();

            // Only owner or admin can update
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            if (property.OwnerId != userId && !User.IsInRole("Admin"))
                return Forbid();

            property.Title = updated.Title;
            property.Description = updated.Description;
            property.Type = updated.Type;
            property.Location = updated.Location;
            property.Features = updated.Features;
            property.PricePerNight = updated.PricePerNight;
            property.Images = updated.Images;

            await _context.SaveChangesAsync();
            return Ok(property);
        }

        // DELETE: api/properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            if (property.OwnerId != userId && !User.IsInRole("Admin"))
                return Forbid();

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Property deleted" });
        }
    }
}
