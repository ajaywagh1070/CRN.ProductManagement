namespace CRN.ProductManagement.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; }
}
