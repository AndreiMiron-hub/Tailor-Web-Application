using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.StaffRelated
{
    public record Jobs : BaseEnumEntity
    {
        public string? JobTitle { get; set; }
    }
}