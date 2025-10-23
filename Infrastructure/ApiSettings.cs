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

public class UserEndpoints
{
    public string Update { get; set; }
    public string ResetPassword { get; set; }
    public string All { get; set; }
    public string ById { get; set; }
    public string Register { get; set; }
    public string RolesById { get; set; }
    public string UpdateRoles { get; set; }
    public string UpdateStatus { get; set; }

    public string GetById(string userId) =>  $"{ById}{userId}";
    public string GetRolesById(string userId) =>  $"{RolesById}{userId}";
    public string UpdateRolesById(string userId) =>  $"{UpdateRoles}{userId}";
}