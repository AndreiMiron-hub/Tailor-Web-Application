using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders
{
    public class OfferedServiceRepository : BaseEntityRepository<OfferedService>, IOfferedServiceRepository
    {
        public OfferedServiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<OfferedService>> GetAll()
        {
            var offeredServices = await applicationDbContext.OfferedServices
                .Where(offeredService => !offeredService.IsDeleted)
                .Include(offeredService => offeredService.ServiceCategory)
                .ToListAsync();

            return offeredServices;
        }

        public override async Task<OfferedService?> GetById(Guid id)
        {
            var offeredServices = await applicationDbContext.OfferedServices
                .Where(offeredService => !offeredService.IsDeleted)
                .Include(offeredService => offeredService.ServiceCategory)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            return offeredServices;
        }

        public override async Task<ICollection<OfferedService>> GetById(ICollection<Guid> ids)
        {
            var offeredService = await applicationDbContext.OfferedServices
                .Where(offeredService => !offeredService.IsDeleted)
                .Where(offeredService => ids.Contains(offeredService.Id))
                .Include(offeredService => offeredService.ServiceCategory)
                .ToListAsync();

            return offeredService;
        }

        public async Task<ICollection<OfferedService>> GetFiltered(ServiceFilter serviceFilter, PaginationFilter paginationFilter)
        {
            return await Get(serviceFilter.GetQuery(), paginationFilter).ToListAsync();
        }
    }
}