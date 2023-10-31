using TailorWebApp.Application.Dtos.Orders.Order;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseOrderDto> Create(OrderDto orderDto);

        Task<ICollection<ResponseOrderDto>> GetFiltered(OrderFilter orderFilter, PaginationFilter paginationFilter);

        Task<ICollection<ResponseOrderDto>> GetAll();

        Task<ResponseOrderDto> GetById(Guid id);

        Task<ICollection<ResponseOrderDto>> GetById(ICollection<Guid> ids);

        Task<ResponseOrderDto> Update(Guid id, OrderDto orderDto);

        Task Delete(Guid id);
    }
}