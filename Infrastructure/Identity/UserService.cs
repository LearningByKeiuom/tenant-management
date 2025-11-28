using Application.Features.Identity.Users;
using Application.Exceptions;
using Application.Features.Identity.Users;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Constants;
using Infrastructure.Contexts;
using Infrastructure.Identity.Models;
using Infrastructure.Tenancy;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _context;
    private readonly IMultiTenantContextAccessor<ABCSchoolTenantInfo> _tenantContextAccessor;

    public UserService(
        UserManager<ApplicationUser> userManager, 
        RoleManager<ApplicationRole> roleManager, 
        ApplicationDbContext context, 
        IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantContextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
        _tenantContextAccessor = tenantContextAccessor;
    }
    
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