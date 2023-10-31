using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Locations
{
    public record Region : BaseEnumEntity
    {
        public string? Name { get; set; }
        public ICollection<Country> Countries { get; set; } = new List<Country>();
    }
}