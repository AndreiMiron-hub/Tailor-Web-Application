using Microsoft.AspNetCore.Identity;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Entities.Accounts
{
    public class AppUserAccount : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}