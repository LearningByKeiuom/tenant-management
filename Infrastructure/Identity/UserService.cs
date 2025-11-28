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