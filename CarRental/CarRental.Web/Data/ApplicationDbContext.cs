using CarRental.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Lease> Leases => Set<Lease>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            b.Entity<Vehicle>().Property(v => v.DailyRate).HasColumnType("decimal(18,2)");
            b.Entity<Payment>().Property(p => p.Amount).HasColumnType("decimal(18,2)");
            b.Entity<Lease>().Property(l => l.TotalCost).HasColumnType("decimal(18,2)");

            // relationships
            b.Entity<Lease>()
                .HasOne(l => l.Vehicle).WithMany(v => v.Leases).HasForeignKey(l => l.VehicleId);
            b.Entity<Lease>()
                .HasOne(l => l.Customer).WithMany(c => c.Leases).HasForeignKey(l => l.CustomerId);
            b.Entity<Payment>()
                .HasOne(p => p.Lease).WithMany(l => l.Payments).HasForeignKey(p => p.LeaseId);
        }
    }
}
