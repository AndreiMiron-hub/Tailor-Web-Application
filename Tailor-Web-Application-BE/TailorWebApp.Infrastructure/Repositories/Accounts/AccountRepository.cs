using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<AppUserAccount> dbSet;

        public AccountRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<AppUserAccount>();
        }

        public async Task<AppUserAccount> GetByEmail(string email)
        {
            var user = await applicationDbContext.Users
                .Where(user => user.Email == email)
                .SingleOrDefaultAsync();

            return user;
        }

        public async Task<AppUserAccount> GetById(string id)
        {
            var user = await applicationDbContext.Users
               .Where(user => user.Id == id)
               .SingleOrDefaultAsync();

            return user;
        }

        public async Task<AppUserAccount> Update(AppUserAccount account)
        {
            dbSet.Update(account);
            await applicationDbContext.SaveChangesAsync();

            return account;
        }
    }
}