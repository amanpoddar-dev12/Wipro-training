using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int LeaseId { get; set; }
        public Lease? Lease { get; set; }
        [DataType(DataType.DateTime)] public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        [Range(0, 999999)] public decimal Amount { get; set; }
    }
}
