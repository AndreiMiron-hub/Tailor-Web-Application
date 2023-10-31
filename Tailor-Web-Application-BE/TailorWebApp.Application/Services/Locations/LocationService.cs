using AutoMapper;
using TailorWebApp.Application.Dtos.Locations.Location;
using TailorWebApp.Application.Services.Locations.Interfaces;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        public LocationService(ILocationRepository locationRepository,
            IMapper mapper)
        {
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseLocationDto> Create(LocationDto locationDto)
        {
            var entity = mapper.Map<Location>(locationDto);
            var location = await locationRepository.Create(entity);

            return mapper.Map<ResponseLocationDto>(location);
        }

        public async Task<ICollection<ResponseLocationDto>> GetAll()
        {
            var locations = await locationRepository.GetAll();

            return mapper.Map<ICollection<ResponseLocationDto>>(locations);
        }

        public async Task<ResponseLocationDto> GetById(Guid id)
        {
            var location = await locationRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ResponseLocationDto>(location);
        }

        public async Task<ICollection<ResponseLocationDto>> GetById(ICollection<Guid> ids)
        {
            var locations = await locationRepository.GetById(ids) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ICollection<ResponseLocationDto>>(locations);
        }

        public async Task<ResponseLocationDto> Update(Guid id, LocationDto locationDto)
        {
            var location = await locationRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            mapper.Map(locationDto, location);
            await locationRepository.Update(location);

            return mapper.Map<ResponseLocationDto>(location);
        }

        public async Task Delete(Guid id)
        {
            var location = await locationRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            await locationRepository.Delete(location);
        }
    }
}