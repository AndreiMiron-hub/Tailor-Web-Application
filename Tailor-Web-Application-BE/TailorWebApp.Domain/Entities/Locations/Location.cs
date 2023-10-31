using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Locations
{
    public record Location : BaseEntity
    {
        public string? StreetAdress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateProvice { get; set; }
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
    }
}