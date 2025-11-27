using Application.Features.Identity.Users;

namespace Infrastructure.Identity;

public class UserService : IUserService
{
    public Task<string> CreateAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> ActivateOrDeactivateAsync(string userId, bool activation)
    {
        throw new NotImplementedException();
    }

    public Task<string> ChangePasswordAsync(ChangePasswordRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> AssignRolesAsync(string userId, UserRolesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserResponse>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> GetByIdAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserRoleResponse>> GetUserRolesAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailTakenAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetUserPermissionsAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsPermissionAssigedAsync(string userId, string permission, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}