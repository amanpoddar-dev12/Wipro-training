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
    [Authorize(Roles = "User,Admin")] // Only Users/Admin can make/view bookings
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/reservations
        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            reservation.UserId = userId;
            reservation.Status = "Pending";

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }

        // GET: api/reservations/my
        [HttpGet("my")]
        public async Task<IActionResult> GetMyReservations()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var reservations = await _context.Reservations
                .Include(r => r.Property)
                .Where(r => r.UserId == userId)
                .ToListAsync();
            return Ok(reservations);
        }

        // PUT: api/reservations/{id}/status
        [HttpPut("{id}/status")]
        [Authorize(Roles = "Owner,Admin")] // Owners/Admin can confirm/cancel
        public async Task<IActionResult> UpdateReservationStatus(int id, [FromBody] string status)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            reservation.Status = status;
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }
    }
}
