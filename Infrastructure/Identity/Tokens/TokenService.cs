using Application.Features.Identity.Tokens;

namespace Infrastructure.Identity.Tokens;

public class TokenService : ITokenService
{
    public Task<TokenResponse> LoginAsync(TokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }
}