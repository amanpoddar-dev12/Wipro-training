using Microsoft.AspNetCore.Identity;

namespace CarRental.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? CustomerId { get; set; } // optional link to Customer row
        public Customer? Customer { get; set; }
    }
}
