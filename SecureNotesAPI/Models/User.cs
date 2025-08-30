using System.ComponentModel.DataAnnotations;

namespace SecureNotesAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(4)]
        public string Username { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
