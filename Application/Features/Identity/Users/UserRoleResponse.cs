namespace Application.Features.Identity.Users;

public class UserRoleResponse
{
    public string RoleId { get; set; } = string.Empty;
    public string Name { get; set; }  = string.Empty;
    public string Description { get; set; }  = string.Empty;
    public bool IsAssigned { get; set; }
}

public class UserRolesResponse
{
    public List<UserRoleResponse> UserRoles { get; set; } = [];
}