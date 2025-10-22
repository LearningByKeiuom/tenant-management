namespace Infrastructure.Models;

public class LoginRequest: TokenRequest
{
    public string Tenant { get; set; } = string.Empty;
}