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
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ User sends a message to the owner of a property
        [HttpPost("send")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> SendMessage([FromBody] Message dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            var property = await _context.Properties.Include(p => p.Owner).FirstOrDefaultAsync(p => p.PropertyId == dto.PropertyId);
            if (property == null)
                return BadRequest(new { message = "Invalid PropertyId" });

            var message = new Message
            {
                FromUserId = userId,
                ToUserId = property.OwnerId,
                PropertyId = dto.PropertyId,
                Content = dto.Content,
                CreatedAt = DateTime.Now
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Message sent!", data = message });
        }

        // ✅ Owner sees all messages from users
        [HttpGet("inbox")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Inbox()
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            var messages = await _context.Messages
                .Include(m => m.FromUser)
                .Include(m => m.Property)
                .Where(m => m.ToUserId == ownerId)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            return Ok(messages);
        }

        // ✅ Owner replies to user
        [HttpPost("reply/{messageId}")]
        [Authorize(Roles = "Owner,Admin")]
        public async Task<IActionResult> Reply(int messageId, [FromBody] string content)
        {
            var ownerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            var originalMessage = await _context.Messages.Include(m => m.FromUser).FirstOrDefaultAsync(m => m.MessageId == messageId);
            if (originalMessage == null) return NotFound(new { message = "Message not found" });

            if (originalMessage.ToUserId != ownerId) return Forbid();

            var reply = new Message
            {
                FromUserId = ownerId,
                ToUserId = originalMessage.FromUserId,
                PropertyId = originalMessage.PropertyId,
                Content = content,
                CreatedAt = DateTime.Now
            };

            _context.Messages.Add(reply);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Reply sent!", data = reply });
        }


        [HttpGet("user")]
        [Authorize(Roles = "User,Admin,Owner")]
        public async Task<IActionResult> UserInbox()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            var messages = await _context.Messages
                .Include(m => m.FromUser)
                .Include(m => m.Property)
                .Where(m => m.ToUserId == userId)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            return Ok(messages);
        }

    }
}
