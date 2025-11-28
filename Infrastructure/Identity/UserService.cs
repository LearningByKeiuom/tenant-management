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
    
    public async Task<string> CreateAsync(CreateUserRequest request)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new ConflictException(["Passwords do not match."]);
        }

        if (await IsEmailTakenAsync(request.Email))
        {
            throw new ConflictException(["Email already taken."]);
        }

        var newUser = new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IsActive = request.IsActive,
            UserName = request.Email,
            EmailConfirmed = true                
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);
        if (!result.Succeeded)
        {
            throw new IdentityException(IdentityHelper.GetIdentityResultErrorDescriptions(result));
        }

        return newUser.Id;
    }

    public Task<string> UpdateAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<string> DeleteAsync(string userId)
    {
        var userInDb = await GetUserAsync(userId);

        if (userInDb.Email == TenancyConstants.Root.Email)
        {
            throw new ConflictException(["Not allowed to remove Admin User for a Root Tenant."]);
        }

        _context.Users.Remove(userInDb);
        await _context.SaveChangesAsync();

        return userId;
    }

    public async Task<string> ActivateOrDeactivateAsync(string userId, bool activation)
    {
        var userInDb = await GetUserAsync(userId);

        userInDb.IsActive = activation;

        var result = await _userManager.UpdateAsync(userInDb);

        if (!result.Succeeded)
        {
            throw new IdentityException(IdentityHelper.GetIdentityResultErrorDescriptions(result));
        }
        return userId;
    }

    public async Task<string> ChangePasswordAsync(ChangePasswordRequest request)
    {
        var userInDb = await GetUserAsync(request.UserId);

        if (request.NewPassword != request.ConfirmNewPassword)
        {
            throw new ConflictException(["Passwords do not match."]);
        }

        var result = await _userManager.ChangePasswordAsync(userInDb, request.CurrentPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            throw new IdentityException(IdentityHelper.GetIdentityResultErrorDescriptions(result));
        }
        return userInDb.Id;
    }


    public Task<string> AssignRolesAsync(string userId, UserRolesRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserResponse>> GetAllAsync(CancellationToken ct)
    {
        var usersInDb = await _userManager.Users.ToListAsync(ct);

        return usersInDb.Adapt<List<UserResponse>>();
    }

    public async Task<UserResponse> GetByIdAsync(string userId, CancellationToken ct)
    {
        var userInDb = await GetUserAsync(userId);

        return userInDb.Adapt<UserResponse>();
    }

    public async Task<List<UserRoleResponse>> GetUserRolesAsync(string userId, CancellationToken ct)
    {
        var userInDb = await GetUserAsync(userId);

        var userRoles = new List<UserRoleResponse>();

        var rolesInDb = await _roleManager.Roles.ToListAsync(ct);

        foreach (var role in rolesInDb)
        {
            userRoles.Add(new UserRoleResponse
            {
                RoleId = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsAssigned = await _userManager.IsInRoleAsync(userInDb, role.Name),
            });
        }

        return userRoles;
    }

    public async Task<bool> IsEmailTakenAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) is not null;
    }

    public async Task<List<string>> GetUserPermissionsAsync(string userId, CancellationToken ct)
    {
        var userInDb = await GetUserAsync(userId);

        var userRolesNames = await _userManager.GetRolesAsync(userInDb);

        var permissions = new List<string>();

        foreach (var role in await _roleManager
                     .Roles
                     .Where(r => userRolesNames.Contains(r.Name))
                     .ToListAsync(ct))
        {
            permissions.AddRange(await _context
                .RoleClaims
                .Where(rc => rc.RoleId == role.Id && rc.ClaimType == ClaimConstants.Permission)
                .Select(rc => rc.ClaimValue)
                .ToListAsync(ct));
        }

        return permissions.Distinct().ToList();
    }

    public Task<bool> IsPermissionAssigedAsync(string userId, string permission, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}