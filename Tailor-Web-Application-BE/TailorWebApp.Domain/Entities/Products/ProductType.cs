using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Products
{
    public record ProductType : BaseEnumEntity
    {
        public string Name { get; set; } = null!;
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}