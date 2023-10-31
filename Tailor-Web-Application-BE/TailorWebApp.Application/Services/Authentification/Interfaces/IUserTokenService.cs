using TailorWebApp.Application.Dtos.Authentication;
using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Application.Services.Authentification.Interfaces
{
    public interface IUserTokenService
    {
        Task<AuthenticationTokensDto> SetTokens(string userId, string accessToken, string refreshToken);

        Task<AuthenticationTokensDto> RefreshAccessToken(AppUserAccount appUserAccount, List<string> roles, AuthenticationTokensDto authenticationTokensDto);

        Task RevokeTokens(string userId);
    }
}