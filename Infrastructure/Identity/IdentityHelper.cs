using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

internal static class IdentityHelper
{
    internal static List<string> GetIdentityResultErrorDescriptions(IdentityResult identityResult)
    {
        return identityResult.Errors.Select(error => error.Description).ToList();
    }
}