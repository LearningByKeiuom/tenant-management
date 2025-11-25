namespace Application.Features.Identity.Users;

public class UserRoleRequest
{
    public string RoleId { get; set; } = string.Empty;
    public string Name { get; set; }  = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public bool IsAssigned { get; set; }
}

public class UserRolesRequest
{
    public List<UserRoleRequest> UserRoles { get; set; } = [];
}