using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Identity;
using TailorWebApp.Application.Services.Authentification.Interfaces;
using TailorWebApp.Application.Services.AzureStorageService.Interfaces;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces;

namespace TailorWebApp.Application.Services.Authentification
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<AppUserAccount> userManager;
        private readonly IAzureStorageService storageService;
        private readonly IMapper mapper;

        public AccountService(IAccountRepository accountRepository,
            UserManager<AppUserAccount> userManager,
            IAzureStorageService azureStorageService,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.userManager = userManager;
            this.storageService = azureStorageService;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> CreateAccount(AppUserAccount user, string password)
        {
            var base64Image = user.ProfilePicture;

            user.ProfilePicture = string.Empty;

            var result = await userManager.CreateAsync(user, password);

            if(result.Succeeded) 
            {
                user.ProfilePicture = await storageService.UploadAsync(base64Image, user.Email);

                await userManager.UpdateAsync(user);
            }

            return result;
        }

        public async Task<ResponseUserDto> GetByEmail(string email)
        {
            var account = await accountRepository.GetByEmail(email) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseUserDto>(account);
        }

        public async Task<ResponseUserDto> GetById(string id)
        {
            var account = await accountRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseUserDto>(account);
        }

        public async Task<ResponseUserDto> Update(string id, RegisterAccountDto account)
        {
            var userAccount = await accountRepository.GetById(id);

            mapper.Map(userAccount, account);

            await accountRepository.Update(userAccount);

            return mapper.Map<ResponseUserDto>(userAccount);
        }
    }
}