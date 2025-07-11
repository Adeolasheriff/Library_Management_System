using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library_Management_System.Application.AuthInterface;
using Library_Management_System.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library_Management_System.Infrastructure.AuthImplementation;

public class JwtUtils : IJwtUtils
{
    private readonly IConfiguration _config;
    public JwtUtils(IConfiguration configuration)
    {
        _config = configuration;
    }
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
