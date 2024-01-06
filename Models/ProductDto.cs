using System.ComponentModel.DataAnnotations;

namespace Product_Tutorial.Models
{
    public class ProductDto
    {


        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";

        [Required]
        public decimal Price { get; set; }


        public string? Description { get; set; }

        public IFormFile? ImageFileName { get; set; }
    }
}
