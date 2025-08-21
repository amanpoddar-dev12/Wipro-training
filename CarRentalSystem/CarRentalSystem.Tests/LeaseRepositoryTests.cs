using Xunit;
using CarRentalSystem.DAO;
using CarRentalSystem.Models.Entity;
using CarRentalSystem.Exceptions;
using System;

namespace CarRentalSystem.Tests
{
    public class LeaseRepositoryTests
    {
        private readonly ICarLeaseRepository repo;

        public LeaseRepositoryTests()
        {
            // Normally, we’d mock DB connection here.
            // For assignment, assume repo is instantiated.
            repo = new CarLeaseRepositoryImpl();
        }

        [Fact]
        public void Test_Lease_Retrieved_Successfully()
        {
            // Arrange: create a lease
            var lease = repo.CreateLease(1, 1, DateTime.Today, DateTime.Today.AddDays(3), "Daily");

            // Act: retrieve lease
            var retrieved = repo.ReturnCar(lease.LeaseID);

            // Assert
            Assert.Equal(lease.LeaseID, retrieved.LeaseID);
        }

        [Fact]
        public void Test_CarNotFoundException()
        {
            Assert.Throws<CarNotFoundException>(() => repo.FindCarById(-99));
        }

        [Fact]
        public void Test_CustomerNotFoundException()
        {
            Assert.Throws<CustomerNotFoundException>(() => repo.FindCustomerById(-88));
        }

        [Fact]
        public void Test_LeaseNotFoundException()
        {
            Assert.Throws<LeaseNotFoundException>(() => repo.ReturnCar(-77));
        }
    }
}
