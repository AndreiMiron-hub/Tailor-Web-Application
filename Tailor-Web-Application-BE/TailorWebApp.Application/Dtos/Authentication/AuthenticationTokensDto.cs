namespace TailorWebApp.Application.Dtos.Authentication
{
    public class AuthenticationTokensDto
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}