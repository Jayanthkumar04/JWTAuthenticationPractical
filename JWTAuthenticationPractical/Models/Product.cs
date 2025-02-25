using System.ComponentModel.DataAnnotations;

namespace JWTAuthenticationPractical.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProName { get; set; }

        public double Price { get; set; }

    }
}
