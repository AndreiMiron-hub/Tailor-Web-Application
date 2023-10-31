using TailorWebApp.Application.Dtos.Orders.OfferedService;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders.Interfaces
{
    public interface IOfferedServiceService
    {
        Task<ResponseOfferedServiceDto> Create(OfferedServiceDto offeredServiceDto);

        Task<ICollection<ResponseOfferedServiceDto>> GetFiltered(ServiceFilter serviceFilter, PaginationFilter paginationFilter);

        Task<ICollection<ResponseOfferedServiceDto>> GetAll();

        Task<ResponseOfferedServiceDto> GetById(Guid id);

        Task<ICollection<ResponseOfferedServiceDto>> GetById(ICollection<Guid> ids);

        Task<ResponseOfferedServiceDto> Update(Guid id, OfferedServiceDto offeredServiceDto);

        Task Delete(Guid id);
    }
}