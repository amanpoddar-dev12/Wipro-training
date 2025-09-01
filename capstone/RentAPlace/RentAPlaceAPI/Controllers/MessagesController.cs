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
    [Authorize] // Both Users and Owners can send messages
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/messages
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            var fromUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            message.FromUserId = fromUserId;
            message.SentAt = DateTime.Now;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }

        // GET: api/messages/conversation/{propertyId}/{userId}
        [HttpGet("conversation/{propertyId}/{userId}")]
        public async Task<IActionResult> GetConversation(int propertyId, int userId)
        {
            var messages = await _context.Messages
                .Where(m => m.PropertyId == propertyId &&
                           (m.FromUserId == userId || m.ToUserId == userId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            return Ok(messages);
        }
    }
}
