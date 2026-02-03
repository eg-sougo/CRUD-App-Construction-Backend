using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.DTOs.Engineers;
using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using ConstructionBackend1._0.DTOs.Auth;
using ConstructionBackend1._0.Services.Implementations;

namespace ConstructionBackend1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ConstructionDbContext _context;
        private readonly IJwtService _config;
        public AuthController(ConstructionDbContext context, IJwtService config) { 
        
            _context= context;
            _config= config;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateEngineerDto engineer)
        {
            User user = new User();
            user.FullName = engineer.FullName;
            user.Email = engineer.Email;
            user.Role = "Engineer";
            user.PhoneNumber= engineer.PhoneNumber;
            user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(engineer.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(engineer);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
          var user=  _context.Users.FirstOrDefault(u => u.Email == dto.Email && u.PhoneNumber == dto.PhoneNumber);
            if (user == null)
            {
                return Unauthorized("Invalid CRedentials");
            }
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.HashedPassword);
            if (!isPasswordValid)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token= _config.GenerateToken(user);


            return Ok(new {token});
        }
    }
}
