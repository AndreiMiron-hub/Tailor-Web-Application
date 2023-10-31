using TailorWebApp.Domain.Entities.Common;
using TailorWebApp.Domain.Entities.Products.JoinEntities;

namespace TailorWebApp.Domain.Entities.Products
{
    public record ProductTag : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<ProductTagJoin> Products { get; set; } = new List<ProductTagJoin>();
    }
}