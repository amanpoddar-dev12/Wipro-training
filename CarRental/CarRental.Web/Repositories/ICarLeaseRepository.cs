using CarRental.Web.Models;

namespace CarRental.Web.Repositories
{
    public interface ICarLeaseRepository
    {
        // Car Management
        Task AddCar(Vehicle car);
        Task RemoveCar(int carId);
        Task<List<Vehicle>> ListAvailableCars();
        Task<List<Vehicle>> ListRentedCars();
        Task<Vehicle> FindCarById(int carId);

        // Customer Management
        Task AddCustomer(Customer customer);
        Task RemoveCustomer(int customerId);
        Task<List<Customer>> ListCustomers();
        Task<Customer> FindCustomerById(int customerId);

        // Lease Management
        Task<Lease> CreateLease(int customerId, int carId, DateOnly start, DateOnly end, LeaseType type);
        Task<Lease> ReturnCar(int leaseId);                    // returns updated lease
        Task<List<Lease>> ListActiveLeases();
        Task<List<Lease>> ListLeaseHistory();

        // Payment Handling
        Task RecordPayment(Lease lease, decimal amount);
        Task<decimal> TotalRevenue();                          // helper for spec's revenue calc
    }
}
