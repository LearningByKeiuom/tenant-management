namespace Infrastructure;

public class ApiSettings
{
    public string BaseApiUrl { get; set; }
    public TokenEndpoints TokenEndpoints { get; set; }
    public UserEndpoints UserEndpoints { get; set; }
    public TenantEndpoints TenantEndpoints { get; set; }
    public RoleEndpoints RoleEndpoints { get; set; }
    public SchoolEndpoints SchoolEndpoints { get; set; }
}

public class TokenEndpoints
{
    public string Login { get; set; }
    public string RefreshToken { get; set; }
}