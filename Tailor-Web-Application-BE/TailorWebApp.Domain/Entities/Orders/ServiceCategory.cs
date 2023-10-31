using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Orders
{
    public record ServiceCategory : BaseEnumEntity
    {
        public string? CategoryName { get; set; }
        public ICollection<OfferedService> OfferedServices { get; set; } = new List<OfferedService>();
    }
}