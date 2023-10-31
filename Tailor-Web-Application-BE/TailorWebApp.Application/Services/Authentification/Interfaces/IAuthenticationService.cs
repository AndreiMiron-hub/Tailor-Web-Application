using System.Security.Claims;
using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Application.Services.Authentification.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateAccessToken(AppUserAccount user, List<string> roles);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    }
}