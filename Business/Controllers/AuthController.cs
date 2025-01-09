using Banking_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Registration.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Data;
using Business.Models;

namespace Banking_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BusinessContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(BusinessContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var userBusiness = _context.Businesses.FirstOrDefault(u => u.Name == request.Username && u.Password == request.Password);
            if (userBusiness == null)
                return Unauthorized();

            var token = GenerateToken(userBusiness);
            return Ok(new { token });
        }

        private string GenerateToken(Busines business)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, business.Name),
                new Claim("BusinessID", business.BusinessID.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
