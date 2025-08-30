using Xunit;
using CarRentalSystem.Models.Entity;
using System;

namespace CarRentalSystem.Tests
{
    public class LeaseTests
    {
        [Fact]
        public void Test_Lease_Creation()
        {
            // Arrange
            var lease = new Lease(1, 101, 201, DateTime.Today, DateTime.Today.AddDays(7), "Daily");

            // Act & Assert
            Assert.Equal(1, lease.LeaseID);
            Assert.Equal(101, lease.VehicleID);
            Assert.Equal(201, lease.CustomerID);
            Assert.Equal("Daily", lease.Type);
        }
    }
}
