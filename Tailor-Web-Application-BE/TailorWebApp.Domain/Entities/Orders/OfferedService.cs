using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Orders
{
    public record OfferedService : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? EstDuration { get; set; }
        public bool IsAvailable { get; set; }
        public string? Images { get; set; }
        public float Discount { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}