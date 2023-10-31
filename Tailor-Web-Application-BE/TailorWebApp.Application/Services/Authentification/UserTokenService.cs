using AutoMapper;
using TailorWebApp.Application.Dtos.Authentication;
using TailorWebApp.Application.Services.Authentification.Interfaces;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces;

namespace TailorWebApp.Application.Services.Authentification
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IAccountTokenRepository accountTokenRepository;
        private readonly IAuthenticationService authenticationService;
        private readonly IMapper mapper;

        public UserTokenService(IAccountTokenRepository accountTokenRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            this.accountTokenRepository = accountTokenRepository;
            this.authenticationService = authenticationService;
            this.mapper = mapper;
        }

        public async Task<AuthenticationTokensDto> SetTokens(string userId, string accessToken, string refreshToken)
        {
            await accountTokenRepository.SetToken(userId, accessToken);
            await accountTokenRepository.SetRefreshToken(userId, refreshToken, DateTime.UtcNow.AddDays(7));

            return new AuthenticationTokensDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        public async Task<AuthenticationTokensDto> RefreshAccessToken(AppUserAccount appUserAccount, List<string> roles, AuthenticationTokensDto authenticationTokensDto)
        {
            var appUserTokens = await accountTokenRepository.GetUserTokens(appUserAccount.Id);

            if (authenticationTokensDto.RefreshToken != appUserTokens.RefreshToken)
            {
                throw new Exception("Invalid Refresh Token");
            }

            if (appUserTokens.RefreshTokenExpiration <= DateTime.UtcNow)
            {
                throw new Exception("Refresh Token expired");
            }

            var newAccessToken = authenticationService.GenerateAccessToken(appUserAccount, roles);
            var appUser = await accountTokenRepository.SetToken(appUserAccount.Id, newAccessToken);

            return mapper.Map<AuthenticationTokensDto>(appUser);
        }

        public async Task RevokeTokens(string userId)
        {
            await accountTokenRepository.RevokeTokens(userId);
        }
    }
}