namespace Application.Features.Identity.Roles;

public class UpdateRolePermissionsRequest
{
    public string RoleId { get; set; } = string.Empty;
    public List<string> NewPermissions { get; set; } = [];
}