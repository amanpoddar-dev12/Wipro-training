using CarRental.Web.Models;
namespace CarRental.Web.Services
{
    public interface ICarLeaseService
    {
        Task<List<Vehicle>> GetAvailableCars();
        Task<Lease> CreateLeaseForUser(int customerId, int carId, DateOnly start, DateOnly end, LeaseType type);
        Task<Lease> ReturnCar(int leaseId);
        Task RecordPayment(int leaseId, decimal amount);
        Task<decimal> TotalRevenue();
    }
}
