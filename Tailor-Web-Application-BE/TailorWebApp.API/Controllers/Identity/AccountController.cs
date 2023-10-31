using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TailorWebApp.Application.Dtos.Authentication;
using TailorWebApp.Application.Dtos.Identity;
using TailorWebApp.Application.Services.Authentification.Interfaces;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Utils.Constants;
using TailorWebApp.Utils.Dtos;

namespace TailorWebApp.BE.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUserAccount> userManager;
        private readonly SignInManager<AppUserAccount> signInManager;
        private readonly Application.Services.Authentification.Interfaces.IAuthenticationService jwtService;
        private readonly IUserTokenService userTokenService;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUserAccount> userManager,
                                SignInManager<AppUserAccount> signInManager,
                                IMapper mapper,
                                Application.Services.Authentification.Interfaces.IAuthenticationService jwtService,
                                IUserTokenService userTokenService,
                                IAccountService accountService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
            this.userTokenService = userTokenService;
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        [Route("createAccount")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AppUserAccount))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponseDto))]
        public async Task<IActionResult> CreateAccount(RegisterAccountDto registerDto)
        {
            var user = mapper.Map<AppUserAccount>(registerDto);
            var result = await accountService.CreateAccount(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [SwaggerOperation(Summary = "Authenticate user and generate token")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request successful", Type = typeof(AuthenticationTokensDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid credentials")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var user = await userManager.FindByNameAsync(loginDto.Email);
            var roles = await userManager.GetRolesAsync(user);
            var token = jwtService.GenerateAccessToken(user, roles.ToList());
            var refreshToken = jwtService.GenerateRefreshToken();
            var response = await userTokenService.SetTokens(user.Id, token, refreshToken);

            return Ok(response);
        }

        [HttpPost]
        [Route("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await accountService.GetByEmail(email);

            return Ok(user);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await accountService.GetById(id);

            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            Response.Headers.Remove(nameof(HttpRequestHeader.Authorization));

            return Ok();
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(AuthenticationTokensDto authenticationTokensDto)
        {
            var principal = jwtService.GetPrincipalFromExpiredToken(authenticationTokensDto.AccessToken);
            var userEmail = principal.Identity?.Name;
            var user = await userManager.FindByNameAsync(userEmail);
            var userRoles = await userManager.GetRolesAsync(user) as List<string>;

            if (user is null)
            {
                return BadRequest("User doesn't exist");
            }

            var response = await userTokenService.RefreshAccessToken(user, userRoles, authenticationTokensDto);

            return Ok(response);
        }

        [HttpPost, Authorize]
        [Route("revokeTokens")]
        public async Task<IActionResult> Revoke()
        {
            var userEmail = User.Identity.Name;
            var user = await userManager.FindByNameAsync(userEmail);

            if (user == null)
            {
                return BadRequest("User doesn't exist");
            }

            await userTokenService.RevokeTokens(user.Id);

            return Ok();
        }
    }
}