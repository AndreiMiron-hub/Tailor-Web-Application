using Microsoft.AspNetCore.Identity;

namespace TailorWebApp.Domain.Entities.Accounts
{
    public class AppUserTokens : IdentityUserToken<string>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}