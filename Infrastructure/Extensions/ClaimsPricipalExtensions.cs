namespace Infrastructure.Extensions;

public static class ClaimsPricipalExtensions
{
    public static string GetEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Email).Value;
    }

    public static string GetFirstname(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Name).Value;
    }

    public static string GetLastname(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.Surname).Value;
    }

    public static string GetTenant(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimConstants.Tenant).Value;
    }

    public static string GetUserId(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

    public static string GetPhoneNumber(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(ClaimTypes.MobilePhone).Value;
    }
}