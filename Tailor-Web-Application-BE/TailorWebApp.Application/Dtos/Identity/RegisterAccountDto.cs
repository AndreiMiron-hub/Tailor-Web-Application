namespace TailorWebApp.Application.Dtos.Identity
{
    public class RegisterAccountDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
    }
}