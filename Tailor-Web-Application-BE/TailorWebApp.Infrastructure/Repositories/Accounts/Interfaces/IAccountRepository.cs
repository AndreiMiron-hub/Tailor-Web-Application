using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUserAccount> GetById(string id);

        Task<AppUserAccount> GetByEmail(string email);

        Task<AppUserAccount> Update(AppUserAccount account);
    }
}