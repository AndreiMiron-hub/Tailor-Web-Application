using TailorWebApp.Application.Dtos.Locations.Region;

namespace TailorWebApp.Application.Dtos.Locations.Country
{
    public class ResponseCountryDto : CountryDto
    {
        public Guid Id { get; set; }
        public ResponseRegionDto? Region { get; set; }
    }
}