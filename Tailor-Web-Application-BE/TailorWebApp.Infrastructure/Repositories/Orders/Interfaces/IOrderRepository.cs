using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Interfaces
{
    public interface IOrderRepository : IBaseEntityRepository<Order>
    {
        Task<ICollection<Order>> GetFiltered(OrderFilter orderFilter, PaginationFilter paginationFilter);
    }
}