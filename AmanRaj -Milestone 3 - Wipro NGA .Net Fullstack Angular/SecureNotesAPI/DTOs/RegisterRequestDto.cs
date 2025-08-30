using System.ComponentModel.DataAnnotations;

namespace SecureNotesAPI.DTOs
{
    public class RegisterRequestDto
    {
        [Required, MinLength(4)]
        public string Username { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
