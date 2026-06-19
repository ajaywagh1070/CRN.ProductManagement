using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRN.ProductManagement.Application.DTOs.Auth;
using CRN.ProductManagement.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CRN.ProductManagement.Infrastructure.Identity;

public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;

public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponseDto GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, username)
    };

        var token =
            new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials);

        return new TokenResponseDto
        {
            AccessToken =
                new JwtSecurityTokenHandler()
                    .WriteToken(token),

            RefreshToken = GenerateRefreshToken(),

            ExpiresAt = token.ValidTo
        };
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

}
