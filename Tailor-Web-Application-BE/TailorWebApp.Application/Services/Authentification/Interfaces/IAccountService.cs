using Microsoft.AspNetCore.Identity;
using TailorWebApp.Application.Dtos.Identity;
using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Application.Services.Authentification.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(AppUserAccount user, string password);

        Task<ResponseUserDto> GetById(string id);

        Task<ResponseUserDto> GetByEmail(string email);

        Task<ResponseUserDto> Update(string id, RegisterAccountDto account);
    }
}