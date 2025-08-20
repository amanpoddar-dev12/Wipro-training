using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [DataType(DataType.Date)] public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)] public DateOnly EndDate { get; set; }

        public LeaseType Type { get; set; }

        public decimal TotalCost { get; set; }   // computed when creating lease
        public bool IsActive { get; set; } = true;

        public ICollection<Payment>? Payments { get; set; }
    }
}
