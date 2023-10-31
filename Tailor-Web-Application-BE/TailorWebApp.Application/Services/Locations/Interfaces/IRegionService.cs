using TailorWebApp.Application.Dtos.Locations.Region;

namespace TailorWebApp.Application.Services.Locations.Interfaces
{
    public interface IRegionService
    {
        Task<ResponseRegionDto> Create(RegionDto regionDto);

        Task<ICollection<ResponseRegionDto>> GetAll();

        Task<ResponseRegionDto> GetById(int id);

        Task<ICollection<ResponseRegionDto>> GetById(ICollection<int> ids);

        Task<ResponseRegionDto> Update(int id, RegionDto regionDto);

        Task Delete(int id);
    }
}