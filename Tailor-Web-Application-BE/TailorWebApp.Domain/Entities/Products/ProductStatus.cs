using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Products
{
    public record ProductStatus : BaseEnumEntity
    {
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}