using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Products
{
    public record ProductCategory : BaseEnumEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}