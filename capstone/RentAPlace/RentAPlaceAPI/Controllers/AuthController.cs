using Microsoft.AspNetCore.Mvc;
using RentAPlaceAPI.Data;
using RentAPlaceAPI.DTOs;
using RentAPlaceAPI.Helpers;
using RentAPlaceAPI.Models;
using RentAPlaceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace RentAPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already exists.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = PasswordHasher.HashPassword(dto.Password),
                Role = dto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.GenerateToken(user);

            return Ok(new
            {
                user.UserId,
                user.Name,
                user.Email,
                user.Role,
                Token = token
            });
        }
    }
}
