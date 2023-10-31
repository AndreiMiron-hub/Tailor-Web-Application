using TailorWebApp.Domain.Entities.Common;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Domain.Entities.Products.JoinEntities;

namespace TailorWebApp.Domain.Entities.Products
{
    public record Product : BaseEntity
    {
        public string? Image { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Material { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public ICollection<ProductTagJoin> Tags { get; set; } = new List<ProductTagJoin>();
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
        public int SizeId { get; set; }
        public ProductSize? Size { get; set; }
        public int StatusId { get; set; }
        public ProductStatus? Status { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}