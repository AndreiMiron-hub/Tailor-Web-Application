using TailorWebApp.Application.Dtos.Locations.Country;

namespace TailorWebApp.Application.Services.Locations.Interfaces
{
    public interface ICountryService
    {
        Task<ResponseCountryDto> Create(CountryDto countryDto);

        Task<ICollection<ResponseCountryDto>> GetAll();

        Task<ResponseCountryDto> GetById(Guid id);

        Task<ICollection<ResponseCountryDto>> GetById(ICollection<Guid> ids);

        Task<ResponseCountryDto> Update(Guid id, CountryDto countryDto);

        Task Delete(Guid id);
    }
}