using Application.Exceptions;
using Application.Features.Identity.Roles;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Constants;
using Infrastructure.Contexts;
using Infrastructure.Identity.Models;
using Infrastructure.Tenancy;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IMultiTenantContextAccessor<ABCSchoolTenantInfo> _tenantInfoContextAccessor;

    public RoleService(
        RoleManager<ApplicationRole> roleManager, 
        UserManager<ApplicationUser> userManager, 
        ApplicationDbContext context, 
        IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantInfoContextAccessor)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
        _tenantInfoContextAccessor = tenantInfoContextAccessor;
    }
    
    public async Task<string> CreateAsync(CreateRoleRequest request)
    {
        var newRole = new ApplicationRole()
        {
            Name = request.Name,
            Description = request.Description
        };

        var result = await _roleManager.CreateAsync(newRole);

        if (!result.Succeeded)
        {
            throw new IdentityException(IdentityHelper.GetIdentityResultErrorDescriptions(result));
        }
        return newRole.Name;
    }

    public Task<string> UpdateAsync(UpdateRoleRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<string> DeleteAsync(string id)
    {
        var roleInDb = await _roleManager.FindByIdAsync(id)
                       ?? throw new NotFoundException(["Role does not exist."]);

        if (RoleConstants.IsDefaultRole(roleInDb.Name))
        {
            throw new ConflictException([$"Not allowed to delete '{roleInDb.Name}' role."]);
        }

        if ((await _userManager.GetUsersInRoleAsync(roleInDb.Name)).Count > 0)
        {
            throw new ConflictException([$"Not allowed to delete '{roleInDb.Name}' role as is currently assigned to users."]);
        }

        var result = await _roleManager.DeleteAsync(roleInDb);
        if (!result.Succeeded)
        {
            throw new IdentityException(IdentityHelper.GetIdentityResultErrorDescriptions(result));
        }

        return roleInDb.Name;
    }

    public Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DoesItExistsAsync(string name)
    {
        return await _roleManager.RoleExistsAsync(name);
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