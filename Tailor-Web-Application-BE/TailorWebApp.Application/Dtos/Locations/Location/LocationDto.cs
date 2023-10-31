namespace TailorWebApp.Application.Dtos.Locations.Location
{
    public class LocationDto
    {
        public string? StreetAdress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateProvice { get; set; }
        public Guid CountryId { get; set; }
    }
}