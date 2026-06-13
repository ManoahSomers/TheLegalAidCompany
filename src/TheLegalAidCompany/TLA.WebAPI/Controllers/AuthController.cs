using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TLA.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AuthController(IConfiguration configuration) : ControllerBase
{
    /// <summary>
    /// Gets a JWT token for the given PPID.
    /// </summary>
    /// <param name="ppid">The PPID of the user.</param>
    /// <returns>A JWT token.</returns>
    [HttpPost]
    public string GenerateToken([FromBody] int ppid)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, ppid.ToString()) };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
