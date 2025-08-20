using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required, MaxLength(50)] public string Make { get; set; } = "";
        [Required, MaxLength(50)] public string Model { get; set; } = "";
        public int Year { get; set; }
        [Range(0, 999999)] public decimal DailyRate { get; set; }
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;
        public int PassengerCapacity { get; set; }
        public int EngineCapacity { get; set; } // cc
        public ICollection<Lease>? Leases { get; set; }
    }
}
