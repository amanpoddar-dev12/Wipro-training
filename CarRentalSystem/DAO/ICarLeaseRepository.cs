using CarRentalSystem.Models.Entity;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.DAO
{
    public interface ICarLeaseRepository
    {
        // Car Management
        void AddCar(Car car);
        void RemoveCar(int carID);
        List<Car> ListAvailableCars();
        List<Car> ListRentedCars();
        Car FindCarById(int carID);

        // Customer Management
        void AddCustomer(Customer customer);
        void RemoveCustomer(int customerID);
        List<Customer> ListCustomers();
        Customer FindCustomerById(int customerID);

        // Lease Management
        Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate, string type);
        Lease ReturnCar(int leaseID);
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();

        // Payment Handling
        void RecordPayment(Lease lease, decimal amount);
        List<Payment> GetPaymentHistory(int customerID);
        decimal GetTotalRevenue();
    }
}
