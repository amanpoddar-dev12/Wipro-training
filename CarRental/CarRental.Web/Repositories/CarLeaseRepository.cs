using CarRental.Web.Data;
using CarRental.Web.Exceptions;
using CarRental.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Web.Repositories.Impl
{
    public class CarLeaseRepository : ICarLeaseRepository
    {
        private readonly ApplicationDbContext _db;
        public CarLeaseRepository(ApplicationDbContext db) { _db = db; }

        // Car Management
        public async Task AddCar(Vehicle car)
        {
            _db.Vehicles.Add(car);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveCar(int carId)
        {
            var car = await _db.Vehicles.FindAsync(carId) ?? throw new CarNotFoundException(carId);
            _db.Vehicles.Remove(car);
            await _db.SaveChangesAsync();
        }

        public Task<List<Vehicle>> ListAvailableCars()
            => _db.Vehicles.Where(v => v.Status == VehicleStatus.Available).ToListAsync();

        public Task<List<Vehicle>> ListRentedCars()
            => _db.Vehicles.Where(v => v.Status == VehicleStatus.NotAvailable).ToListAsync();

        public async Task<Vehicle> FindCarById(int carId)
            => await _db.Vehicles.FindAsync(carId) ?? throw new CarNotFoundException(carId);

        // Customer Management
        public async Task AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveCustomer(int customerId)
        {
            var c = await _db.Customers.FindAsync(customerId) ?? throw new CustomerNotFoundException(customerId);
            _db.Customers.Remove(c);
            await _db.SaveChangesAsync();
        }

        public Task<List<Customer>> ListCustomers() => _db.Customers.AsNoTracking().ToListAsync();

        public async Task<Customer> FindCustomerById(int customerId)
            => await _db.Customers.FindAsync(customerId) ?? throw new CustomerNotFoundException(customerId);

        // Lease Management
        public async Task<Lease> CreateLease(int customerId, int carId, DateOnly start, DateOnly end, LeaseType type)
        {
            var car = await FindCarById(carId);
            var cust = await FindCustomerById(customerId);

            if (car.Status == VehicleStatus.NotAvailable)
                throw new InvalidOperationException("Car is not available.");

            var days = Math.Max(1, end.DayNumber - start.DayNumber + 1);
            decimal total = type == LeaseType.Daily
                ? car.DailyRate * days
                : car.DailyRate * 30 * Math.Max(1, (int)Math.Ceiling(days / 30m)); // simple monthly calc per spec need

            var lease = new Lease
            {
                VehicleId = car.VehicleId,
                CustomerId = cust.CustomerId,
                StartDate = start,
                EndDate = end,
                Type = type,
                TotalCost = decimal.Round(total, 2),
                IsActive = true
            };

            car.Status = VehicleStatus.NotAvailable;

            _db.Leases.Add(lease);
            _db.Vehicles.Update(car);
            await _db.SaveChangesAsync();
            return lease;
        }

        public async Task<Lease> ReturnCar(int leaseId)
        {
            var lease = await _db.Leases.Include(l => l.Vehicle).FirstOrDefaultAsync(l => l.LeaseId == leaseId)
                        ?? throw new LeaseNotFoundException(leaseId);
            if (!lease.IsActive) return lease;

            lease.IsActive = false;
            if (lease.Vehicle != null)
            {
                lease.Vehicle.Status = VehicleStatus.Available;
                _db.Vehicles.Update(lease.Vehicle);
            }

            _db.Leases.Update(lease);
            await _db.SaveChangesAsync();
            return lease;
        }

        public Task<List<Lease>> ListActiveLeases()
            => _db.Leases.Include(l => l.Vehicle).Include(l => l.Customer).Where(l => l.IsActive).ToListAsync();

        public Task<List<Lease>> ListLeaseHistory()
            => _db.Leases.Include(l => l.Vehicle).Include(l => l.Customer).Where(l => !l.IsActive).ToListAsync();

        // Payments
        public async Task RecordPayment(Lease lease, decimal amount)
        {
            var dbLease = await _db.Leases.FindAsync(lease.LeaseId) ?? throw new LeaseNotFoundException(lease.LeaseId);
            _db.Payments.Add(new Payment { LeaseId = dbLease.LeaseId, Amount = amount, PaymentDate = DateTime.UtcNow });
            await _db.SaveChangesAsync();
        }

        public Task<decimal> TotalRevenue() => _db.Payments.SumAsync(p => (decimal?)p.Amount ?? 0m);
    }
}
