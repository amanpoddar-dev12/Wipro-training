using System.ComponentModel.DataAnnotations;

namespace CarRental.Web.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MaxLength(50)] public string FirstName { get; set; } = "";
        [Required, MaxLength(50)] public string LastName { get; set; } = "";
        [Required, EmailAddress] public string Email { get; set; } = "";
        [Required, MaxLength(20)] public string PhoneNumber { get; set; } = "";
        public ICollection<Lease>? Leases { get; set; }
    }
}
