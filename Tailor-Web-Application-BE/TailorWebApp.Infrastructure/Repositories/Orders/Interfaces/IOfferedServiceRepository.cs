using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Interfaces
{
    public interface IOfferedServiceRepository : IBaseEntityRepository<OfferedService>
    {
        Task<ICollection<OfferedService>> GetFiltered(ServiceFilter serviceFilter, PaginationFilter paginationFilter);
    }
}