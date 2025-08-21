using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
