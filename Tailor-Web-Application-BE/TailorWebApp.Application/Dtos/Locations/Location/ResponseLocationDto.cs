using TailorWebApp.Application.Dtos.Locations.Country;

namespace TailorWebApp.Application.Dtos.Locations.Location
{
    public class ResponseLocationDto : LocationDto
    {
        public Guid Id { get; set; }
        public ResponseCountryDto? Country { get; set; }
    }
}