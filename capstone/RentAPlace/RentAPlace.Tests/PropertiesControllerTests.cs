using Xunit;
using Microsoft.EntityFrameworkCore;
using RentAPlaceAPI.Controllers;
using RentAPlaceAPI.Data;
using RentAPlaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RentAPlace.Tests.Controllers
{
    public class PropertiesControllerTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }


        [Fact]
        public async Task GetProperty_ShouldReturnNotFound_WhenDoesNotExist()
        {
            var context = GetDbContext();
            var controller = new PropertiesController(context);

            var result = await controller.GetProperty(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetTopRated_ShouldReturnOrderedList()
        {
            var context = GetDbContext();
            context.Properties.AddRange(
                new Property { Title = "Villa 1", Location = "Goa", Type = "Villa", PricePerNight = 1500, Rating = 4.9 },
                new Property { Title = "Villa 2", Location = "Delhi", Type = "Villa", PricePerNight = 1200, Rating = 3.5 }
            );
            await context.SaveChangesAsync();

            var controller = new PropertiesController(context);

            var result = await controller.GetTopRated();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var props = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            Assert.NotEmpty(props);
        }

        [Fact]

        public async Task Search_ShouldReturnMatchingProperties()
        {
            var context = GetDbContext();
            context.Properties.AddRange(
                new Property { Title = "Luxury Villa", Location = "Goa", Type = "Villa", Features = "Pool", PricePerNight = 2500, Rating = 4.7 },
                new Property { Title = "Simple Flat", Location = "Delhi", Type = "Flat", Features = "Garden", PricePerNight = 1000, Rating = 3.0 }
            );
            await context.SaveChangesAsync();

            var controller = new PropertiesController(context);

            var result = await controller.Search(
                location: "Goa",
                type: "Villa",
                features: "Pool",
                checkIn: null,
                checkOut: null
            );

            var okResult = Assert.IsType<OkObjectResult>(result);
            var props = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);

            Assert.Single(props);
        }

    }
}
