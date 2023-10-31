using AutoMapper;
using TailorWebApp.Application.Dtos.Locations.Region;
using TailorWebApp.Application.Services.Locations.Interfaces;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Application.Services.Locations
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionService(IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseRegionDto> Create(RegionDto regionDto)
        {
            var entity = mapper.Map<Region>(regionDto);
            var region = await regionRepository.Create(entity);

            return mapper.Map<ResponseRegionDto>(region);
        }

        public async Task<ICollection<ResponseRegionDto>> GetAll()
        {
            var regions = await regionRepository.GetAll();

            return mapper.Map<ICollection<ResponseRegionDto>>(regions);
        }

        public async Task<ResponseRegionDto> GetById(int id)
        {
            var region = await regionRepository.GetById(id) ?? throw new Exception(); // exception middleware

            return mapper.Map<ResponseRegionDto>(region);
        }

        public async Task<ICollection<ResponseRegionDto>> GetById(ICollection<int> ids)
        {
            var regions = await regionRepository.GetById(ids) ?? throw new Exception(); // exception middleware

            return mapper.Map<ICollection<ResponseRegionDto>>(regions);
        }

        public async Task<ResponseRegionDto> Update(int id, RegionDto regionDto)
        {
            var region = await regionRepository.GetById(id) ?? throw new Exception(); // exception middleware

            mapper.Map(regionDto, region);
            await regionRepository.Update(region);

            return mapper.Map<ResponseRegionDto>(region);
        }

        public async Task Delete(int id)
        {
            var region = await regionRepository.GetById(id) ?? throw new Exception(); // exception middleware

            await regionRepository.Delete(region);
        }
    }
}