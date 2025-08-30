using Microsoft.AspNetCore.Mvc;
using SecureNotesAPI.Data;
using SecureNotesAPI.Models;
using BCrypt.Net;

using SecureNotesAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using SecureNotesAPI.DTOs;


namespace SecureNotesAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly JwtService _jwtService;


        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                return BadRequest(new { message = "Username already exists" });

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);


            var user = new User
            {
                Username = request.Username,
                PasswordHash = hashedPassword
            };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully. Please log in." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);


            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))

                return Unauthorized(new { message = "Invalid username or password" });

            var token = _jwtService.GenerateToken(user.Id, user.Username);

            return Ok(new
            {
                token,
                expires_in = 3600,
                user = new { username = user.Username }
            });
        }
    }
}
