using Microsoft.AspNetCore.Mvc;
using CRN.ProductManagement.Application.DTOs.Auth;
using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Infrastructure.Data;
using CRN.ProductManagement.Domain.Entities;

namespace CRN.ProductManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly ApplicationDbContext _context;

public AuthController(
    ITokenService tokenService,
    ApplicationDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        if (request.UserName != "admin" ||
            request.Password != "admin123")
        {
            return Unauthorized();
        }

        var token = _tokenService.GenerateToken(request.UserName);

        var refreshToken = new RefreshToken
        {
            UserName = request.UserName,
            Token = token.RefreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        _context.RefreshTokens.Add(refreshToken);
        _context.SaveChanges();

        return Ok(token);
    }

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken(
        RefreshTokenRequestDto request)
    {
        var storedToken = _context.RefreshTokens
            .FirstOrDefault(x =>
                x.Token == request.RefreshToken &&
                !x.IsRevoked &&
                x.Expires > DateTime.UtcNow);

        if (storedToken == null)
        {
            return Unauthorized("Invalid Refresh Token");
        }

        var newToken =
            _tokenService.GenerateToken(
                storedToken.UserName);

        storedToken.IsRevoked = true;

        _context.RefreshTokens.Add(
            new RefreshToken
            {
                UserName = storedToken.UserName,
                Token = newToken.RefreshToken,
                Expires = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            });

        _context.SaveChanges();

        return Ok(newToken);
    }

}
