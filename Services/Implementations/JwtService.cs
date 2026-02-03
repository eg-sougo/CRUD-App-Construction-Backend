using ConstructionBackend1._0.Models;
using ConstructionBackend1._0.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConstructionBackend1._0.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>();

            Claim c1= new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString());
            Claim c2 = new Claim(ClaimTypes.Email, user.Email!);
            Claim c3 = new Claim(ClaimTypes.Role, user.Role!);

            claims.Add(c1);
            claims.Add(c2);
            claims.Add(c3);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(50),
                signingCredentials: creds
                );


            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }
    
    }


}

