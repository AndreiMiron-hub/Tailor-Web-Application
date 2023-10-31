using TailorWebApp.Application.Dtos.Locations.Location;

namespace TailorWebApp.Application.Services.Locations.Interfaces
{
    public interface ILocationService
    {
        Task<ResponseLocationDto> Create(LocationDto locationDto);

        Task<ICollection<ResponseLocationDto>> GetAll();

        Task<ResponseLocationDto> GetById(Guid id);

        Task<ICollection<ResponseLocationDto>> GetById(ICollection<Guid> ids);

        Task<ResponseLocationDto> Update(Guid id, LocationDto locationDto);

        Task Delete(Guid id);
    }
}