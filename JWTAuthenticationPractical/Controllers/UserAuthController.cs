using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationPractical.Data;
using JWTAuthenticationPractical.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthenticationPractical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserAuthController(ProductDbContext _context) : ControllerBase
    {
        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] Users user)
        {
            var userr = _context.Users.FirstOrDefault(x=>x.UserName == user.UserName);

            var extUser = _context
                .Users.FirstOrDefault(u=> u.UserName == user.UserName && u.UserPassword == user.UserPassword);

            if (extUser == null) {

                return BadRequest("User not found");
            
            }

            else
            {
                
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"));
                var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:7287",
                    audience: "http://localhost:7287",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredential
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new LoginResponse { Token = tokenString, UserName = user.UserName });


            }

        }

    }
}
