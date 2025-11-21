namespace Infrastructure;

public class ApiSettings
{
    public string BaseApiUrl { get; set; } = string.Empty;
    public TokenEndpoints TokenEndpoints { get; set; } = new();
    public UserEndpoints UserEndpoints { get; set; } = new();
    public TenantEndpoints TenantEndpoints { get; set; } = new();
    public RoleEndpoints RoleEndpoints { get; set; } = new();
    public SchoolEndpoints SchoolEndpoints { get; set; } = new();
}

public class TokenEndpoints
{
    public string Login { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class UserEndpoints
{
    public string Update { get; set; } = string.Empty;
    public string ResetPassword { get; set; } = string.Empty;
    public string All { get; set; } = string.Empty;
    public string ById { get; set; } = string.Empty;
    public string Register { get; set; } = string.Empty;
    public string RolesById { get; set; } = string.Empty;
    public string UpdateRoles { get; set; } = string.Empty;
    public string UpdateStatus { get; set; } = string.Empty;

    public string GetById(string userId) =>  $"{ById}{userId}";
    public string GetRolesById(string userId) =>  $"{RolesById}{userId}";
    public string UpdateRolesById(string userId) =>  $"{UpdateRoles}{userId}";
}

public class TenantEndpoints
{ 
    public string Create { get; set; } = string.Empty;
    public string Upgrade { get; set; } = string.Empty;
    public string All { get; set; } = string.Empty;
    public string ById { get; set; } = string.Empty;
    public string Activate { get; set; } = string.Empty;
    public string DeActivate { get; set; } = string.Empty;

    public string GetById(string tenantId)
    {
        return $"{ById}{tenantId}";
    }

    public string FullActivate(string tenantId)
    {
        return $"{Activate}{tenantId}/activate";
    }
    public string FullDeActivate(string tenantId)
    {
        return $"{DeActivate}{tenantId}/deactivate";
    }
}

public class RoleEndpoints
{
    public string Create { get; set; } = string.Empty;
    public string Update { get; set; } = string.Empty;
    public string PartialById { get; set; } = string.Empty;
    public string FullById { get; set; } = string.Empty;
    public string All { get; set; } = string.Empty;
    public string Delete { get; set; } = string.Empty;
    public string UpdatePermissions { get; set; } = string.Empty;

    public string GetPartial(string roleId)
        => $"{PartialById}{roleId}";

    public string GetFull(string roleId)
        => $"{FullById}{roleId}";

    public string GetDelete(string roleId)
        => $"{Delete}{roleId}";
}

public class SchoolEndpoints
{
    public string Create { get; set; } = string.Empty;
    public string Update { get; set; } = string.Empty;
    public string Delete { get; set; } = string.Empty;
    public string ById { get; set; } = string.Empty;
    public string ByName { get; set; } = string.Empty;
    public string All { get; set; } = string.Empty;

    public string GetById(string schoolId)
        => $"{ById}{schoolId}";
    public string GetByName(string schoolName)
        => $"{ByName}{schoolName}";
    public string GetDelete(string schoolId)
        => $"{Delete}{schoolId}";
}