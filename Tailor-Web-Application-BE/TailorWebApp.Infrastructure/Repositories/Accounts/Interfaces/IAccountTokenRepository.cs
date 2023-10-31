using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces
{
    public interface IAccountTokenRepository
    {
        public Task AddUserTokens(AppUserTokens appUserTokens);

        public Task<AppUserTokens?> SetToken(string userId, string accessToken);

        public Task<AppUserTokens?> SetRefreshToken(string userId, string refreshToken, DateTime expirationDate);

        public Task<AppUserTokens?> GetUserTokens(string userId);

        public Task<AppUserTokens?> RevokeTokens(string userId);
    }
}