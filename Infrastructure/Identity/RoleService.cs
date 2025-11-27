using Application.Features.Identity.Roles;

namespace Infrastructure.Identity;

public class RoleService : IRoleService
{
    public Task<string> CreateAsync(CreateRoleRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(UpdateRoleRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DoesItExistsAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<RoleResponse>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<RoleResponse> GetByIdAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<RoleResponse> GetRoleWithPermissionsAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}