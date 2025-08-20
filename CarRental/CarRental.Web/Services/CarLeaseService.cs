using CarRental.Web.Models;
using CarRental.Web.Repositories;

namespace CarRental.Web.Services
{
    public class CarLeaseService : ICarLeaseService
    {
        private readonly ICarLeaseRepository _repo;
        public CarLeaseService(ICarLeaseRepository repo) { _repo = repo; }

        public Task<List<Vehicle>> GetAvailableCars() => _repo.ListAvailableCars();

        public Task<Lease> CreateLeaseForUser(int customerId, int carId, DateOnly start, DateOnly end, LeaseType type)
            => _repo.CreateLease(customerId, carId, start, end, type);

        public Task<Lease> ReturnCar(int leaseId) => _repo.ReturnCar(leaseId);

        public async Task RecordPayment(int leaseId, decimal amount)
        {
            var lease = new Lease { LeaseId = leaseId };
            await _repo.RecordPayment(lease, amount);
        }

        public Task<decimal> TotalRevenue() => _repo.TotalRevenue();
    }
}
