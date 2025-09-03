using Xunit;
using Moq;
using BCrypt.Net;

using RentAPlaceAPI.Controllers;
using RentAPlaceAPI.Data;
using RentAPlaceAPI.Models;
using RentAPlaceAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;

public class AuthControllerTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("AuthTestDb")
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task Register_ShouldCreateUser()
    {
        var context = GetDbContext();
        var tokenService = new Mock<TokenService>(null!);
        var controller = new AuthController(context, tokenService.Object);

        var result = await controller.Register(new RentAPlaceAPI.DTOs.RegisterDto
        {
            Name = "Test User",
            Email = "test@example.com",
            Password = "Password123"
        });

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Login_ShouldReturnUnauthorized_IfWrongPassword()
    {
        var context = GetDbContext();
        context.Users.Add(new User
        {
            Name = "Test",
            Email = "test@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123")
,
            Role = "User"
        });
        context.SaveChanges();

        var tokenService = new Mock<TokenService>(null!);
        var controller = new AuthController(context, tokenService.Object);

        var result = await controller.Login(new RentAPlaceAPI.DTOs.LoginDto
        {
            Email = "test@example.com",
            Password = "WrongPass"
        });

        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}
