using Xunit;
using CarRentalSystem.Models.Entity;

namespace CarRentalSystem.Tests
{
    public class CarTests
    {
        [Fact]
        public void Test_Car_Creation()
        {
            // Arrange
            var car = new Car(1, "Toyota", "Corolla", 2021, 1500, "available", 5, "1800cc");

            // Act & Assert
            Assert.Equal(1, car.VehicleID);
            Assert.Equal("Toyota", car.Make);
            Assert.Equal("Corolla", car.Model);
            Assert.Equal(2021, car.Year);
            Assert.Equal(1500, car.DailyRate);
            Assert.Equal("available", car.Status);
        }
    }
}
