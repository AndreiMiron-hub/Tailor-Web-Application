using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Accounts
{
    public class AccountTokenRepository : IAccountTokenRepository
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<AppUserTokens> dbSet;

        public AccountTokenRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<AppUserTokens>();
        }

        public async Task<AppUserTokens?> SetToken(string userId, string accessToken)
        {
            var appUserTokens = await dbSet.Where(userTokens => userTokens.UserId == userId).FirstAsync();
            appUserTokens.LoginProvider = "Bearer";
            appUserTokens.Name = "JWT";
            appUserTokens.Value = accessToken;
            dbSet.Update(appUserTokens);
            await applicationDbContext.SaveChangesAsync();

            return appUserTokens;
        }

        public async Task<AppUserTokens?> SetRefreshToken(string userId, string refreshToken, DateTime expirationDate)
        {
            var appUserTokens = await dbSet.Where(userTokens => userTokens.UserId == userId).FirstAsync();
            appUserTokens.RefreshToken = refreshToken;
            appUserTokens.RefreshTokenExpiration = expirationDate;
            dbSet.Update(appUserTokens);
            await applicationDbContext.SaveChangesAsync();

            return appUserTokens;
        }

        public async Task<AppUserTokens?> RevokeTokens(string userId)
        {
            var appUserTokens = await dbSet.Where(userTokens => userTokens.UserId == userId).FirstAsync();
            appUserTokens.RefreshToken = string.Empty;
            appUserTokens.Value = string.Empty;
            appUserTokens.RefreshTokenExpiration = default;
            dbSet.Update(appUserTokens);
            await applicationDbContext.SaveChangesAsync();

            return appUserTokens;
        }

        public async Task AddUserTokens(AppUserTokens appUserTokens)
        {
            await dbSet.AddAsync(appUserTokens);
        }

        public async Task<AppUserTokens?> GetUserTokens(string userId)
        {
            var appUserTokens = await dbSet.Where(userTokens => userTokens.UserId == userId).FirstAsync();

            return appUserTokens;
        }
    }
}