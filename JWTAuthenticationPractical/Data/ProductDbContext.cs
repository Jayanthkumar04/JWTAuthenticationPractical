using JWTAuthenticationPractical.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthenticationPractical.Data
{
    public class ProductDbContext:DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) { 
        
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Users> Users { get; set; }


    }
}
