using Application.Features.Identity.Tokens;
using Application;
using Application.Exceptions;
using Application.Features.Identity.Tokens;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Constants;
using Infrastructure.Identity.Models;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Identity.Tokens;

public class TokenService : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IMultiTenantContextAccessor<ABCSchoolTenantInfo> _tenantContextAccessor;
    private readonly JwtSettings _jwtSettings;

    public TokenService(
        UserManager<ApplicationUser> userManager,
        IMultiTenantContextAccessor<ABCSchoolTenantInfo> tenantContextAccessor,
        RoleManager<ApplicationRole> roleManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _tenantContextAccessor = tenantContextAccessor;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings.Value;
    }
    
    public async Task<TokenResponse> LoginAsync(TokenRequest request)
    {
        #region Validations
        if (!_tenantContextAccessor.MultiTenantContext.TenantInfo.IsActive)
        {
            throw new UnauthorizedException(["Tenant subscription is not active. Contact Administrator."]);
        }

        var userInDb = await _userManager.FindByNameAsync(request.Username)
                       ?? throw new UnauthorizedException(["Authentication not successful."]);

        if (!await _userManager.CheckPasswordAsync(userInDb, request.Password))
        {
            throw new UnauthorizedException(["Incorrect Username or Password."]);
        }

        if (!userInDb.IsActive)
        {
            throw new UnauthorizedException(["User Not Active. Contact Administrator."]);
        }

        if (_tenantContextAccessor.MultiTenantContext.TenantInfo.Id is not TenancyConstants.Root.Id)
        {
            if (_tenantContextAccessor.MultiTenantContext.TenantInfo.ValidUpTo < DateTime.UtcNow)
            {
                throw new UnauthorizedException(["Tenant Subscription has expired. Contact Administrator."]);
            }
        }
        #endregion

        // Generate jwt
        return await GenerateTokenAndUpdateUserAsync(userInDb);
    }

    public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var userPrincipal = GetClaimsPrincipalFromExpiringToken(request.CurrentJwt);
        var userEmail = userPrincipal.GetEmail();

        var userInDb = await _userManager.FindByEmailAsync(userEmail)
                       ?? throw new UnauthorizedException(["Authentication failed."]);

        if (userInDb.RefreshToken != request.CurrentRefreshToken || userInDb.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new UnauthorizedException(["Invalid token."]);
        }

        return await GenerateTokenAndUpdateUserAsync(userInDb);
    }
    
    private ClaimsPrincipal GetClaimsPrincipalFromExpiringToken(string expiringToken)
    {
        var tkValidationParams = new TokenValidationParameters 
        { 
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var pricipal = tokenHandler.ValidateToken(expiringToken, tkValidationParams, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new UnauthorizedException(["Invalid token provided. Failed to generate new token."]);
        }

        return pricipal;
    }

}