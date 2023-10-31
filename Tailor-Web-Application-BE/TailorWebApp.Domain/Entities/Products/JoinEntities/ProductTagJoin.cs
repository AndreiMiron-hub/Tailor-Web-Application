using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Products.JoinEntities
{
    public record ProductTagJoin : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
        public Product? Product { get; set; }
        public ProductTag? Tag { get; set; }
    }
}