using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 999999)]
        public decimal Price { get; set; }

        [StringLength(60)]
        public string? Category { get; set; }
    }
}
