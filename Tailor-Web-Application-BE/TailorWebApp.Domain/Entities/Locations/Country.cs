using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Locations
{
    public record Country : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Location>? Locations { get; set; }
        public int RegionId { get; set; }
        public Region? Region { get; set; }
    }
}