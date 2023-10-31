using AutoMapper;
using TailorWebApp.Application.Dtos.Locations.Country;
using TailorWebApp.Application.Services.Locations.Interfaces;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Application.Services.Locations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryService(ICountryRepository countryRepository,
            IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseCountryDto> Create(CountryDto countryDto)
        {
            var entity = mapper.Map<Country>(countryDto);
            var country = await countryRepository.Create(entity);

            return mapper.Map<ResponseCountryDto>(country);
        }

        public async Task<ICollection<ResponseCountryDto>> GetAll()
        {
            var countries = await countryRepository.GetAll();

            return mapper.Map<ICollection<ResponseCountryDto>>(countries);
        }

        public async Task<ResponseCountryDto> GetById(Guid id)
        {
            var country = await countryRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ResponseCountryDto>(country);
        }

        public async Task<ICollection<ResponseCountryDto>> GetById(ICollection<Guid> ids)
        {
            var countries = await countryRepository.GetById(ids) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ICollection<ResponseCountryDto>>(countries);
        }

        public async Task<ResponseCountryDto> Update(Guid id, CountryDto countryDto)
        {
            var country = await countryRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            mapper.Map(countryDto, country);
            await countryRepository.Update(country);

            return mapper.Map<ResponseCountryDto>(country);
        }

        public async Task Delete(Guid id)
        {
            var country = await countryRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            await countryRepository.Delete(country);
        }
    }
}