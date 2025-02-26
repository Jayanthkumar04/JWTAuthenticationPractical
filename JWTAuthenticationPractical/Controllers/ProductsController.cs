using JWTAuthenticationPractical.Data;
using JWTAuthenticationPractical.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthenticationPractical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController(ProductDbContext _context) : ControllerBase
    {
        [HttpGet("ALL PRODUCTS")]
        public async Task<IActionResult> GetAll()
        {
            var products =await _context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpGet("ALLUSERS")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            CreatedAtAction(nameof(GetAll), new { Id = product.Id, product});

            return NoContent();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            CreatedAtAction(nameof(GetAllUsers), new { Id = user.Id, user });

            return NoContent();
        }

        



    }
}
    