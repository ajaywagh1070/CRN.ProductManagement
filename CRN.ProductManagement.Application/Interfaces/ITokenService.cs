using CRN.ProductManagement.Application.DTOs.Auth;

namespace CRN.ProductManagement.Application.Interfaces;

public interface ITokenService
{
    TokenResponseDto GenerateToken(string username);

string GenerateRefreshToken();

}
