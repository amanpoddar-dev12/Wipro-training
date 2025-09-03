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
    public class PropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("my")]
        [Authorize(Roles = "Owner,Admin,User")]
        public async Task<IActionResult> GetMyProperties()
        {
            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim))
                    return Unauthorized(new { message = "User not found in token" });

                var userId = int.Parse(userIdClaim);

                var myProps = await _context.Properties
                    .Where(p => p.OwnerId == userId)
                    .ToListAsync();

                return Ok(myProps);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to fetch properties", error = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProperties()
        {
            var props = await _context.Properties.Include(p => p.Owner).ToListAsync();
            return Ok(props);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _context.Properties.Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (property == null) return NotFound();

            return Ok(property);
        }


        [HttpPost]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> AddProperty(Property property)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            property.OwnerId = userId;

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return Ok(property);
        }

        // ✅ Only Owner/Admin can update
        [HttpPut("{id}")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> UpdateProperty(int id, Property updated)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return NotFound();

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
            property.Rating = updated.Rating;

            await _context.SaveChangesAsync();
            return Ok(property);
        }

        // ✅ Only Owner/Admin can delete
        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner,Admin")]
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

        // ✅ Public: Top-rated properties
        [HttpGet("top-rated")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTopRated()
        {
            var grouped = await _context.Properties
                .OrderByDescending(p => p.Rating)
                .GroupBy(p => p.Type) // group by category (Villa, Apartment, etc.)
                .Select(g => new
                {
                    Category = g.Key,
                    Properties = g.Take(5) // top 5 per category
                        .Select(p => new
                        {
                            p.PropertyId,
                            p.Title,
                            p.Type,
                            p.Location,
                            p.PricePerNight,
                            p.Rating,
                            p.Images
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(grouped);
        }



        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(
    [FromQuery] string? location,
    [FromQuery] string? type,
    [FromQuery] string? features,
    [FromQuery] DateTime? checkIn,
    [FromQuery] DateTime? checkOut)
        {
            try
            {
                var query = _context.Properties
                    .Include(p => p.Reservations) // ✅ include reservations
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(location))
                    query = query.Where(p => p.Location.Contains(location));

                if (!string.IsNullOrWhiteSpace(type))
                    query = query.Where(p => p.Type.Contains(type));

                if (!string.IsNullOrWhiteSpace(features))
                    query = query.Where(p => p.Features != null && p.Features.Contains(features));

                // ✅ Filter by availability (exclude properties already reserved in the date range)
                if (checkIn.HasValue && checkOut.HasValue)
                {
                    query = query.Where(p => !p.Reservations.Any(r =>
                        (checkIn.Value < r.CheckOut && checkOut.Value > r.CheckIn)
                    ));
                }

                var results = await query
                    .OrderByDescending(p => p.Rating)
                    .Select(p => new
                    {
                        p.PropertyId,
                        p.Title,
                        p.Type,
                        p.Location,
                        p.PricePerNight,
                        p.Rating,
                        p.Images
                    })
                    .ToListAsync();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Search failed", error = ex.Message });
            }
        }




        [HttpPost("upload-images")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded.");

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "properties");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var imageUrls = new List<string>();
            foreach (var file in files)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                imageUrls.Add($"{baseUrl}/uploads/properties/{fileName}");
            }

            return Ok(imageUrls);
        }



    }
}
