using System.ComponentModel.DataAnnotations;

namespace day25.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(60)]
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}
