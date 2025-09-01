using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureNotesAPI.Data;
using SecureNotesAPI.Models;
using System.Security.Claims;

namespace SecureNotesAPI.Controllers
{
   
    [ApiController]
    [Route("api/notes")]
    [Authorize]



    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Note note)
        {
            note.UserId = GetUserId();
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Note added successfully.", noteId = note.Id });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userId = GetUserId();
            var notes = _context.Notes.Where(n => n.UserId == userId).ToList();
            return Ok(notes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Note request)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null || note.UserId != GetUserId())
                return Unauthorized(new { message = "Not allowed" });

            note.Title = request.Title;
            note.Content = request.Content;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null || note.UserId != GetUserId())
                return Unauthorized(new { message = "Not allowed" });

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note deleted successfully" });
        }
    }
}
