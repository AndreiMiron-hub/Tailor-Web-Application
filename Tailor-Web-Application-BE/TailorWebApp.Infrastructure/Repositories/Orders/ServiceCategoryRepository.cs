using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Orders
{
    public class ServiceCategoryRepository : BaseEnumEntityRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<ServiceCategory>> GetAll()
        {
            var serviceCategories = await applicationDbContext.ServiceCategories
                .Where(serviceCategory => !serviceCategory.IsDeleted)
                .ToListAsync();

            return serviceCategories;
        }

        public override async Task<ServiceCategory?> GetById(int id)
        {
            var serviceCategory = await applicationDbContext.ServiceCategories
                .Where(serviceCategory => !serviceCategory.IsDeleted)
                .Where(serviceCategory => serviceCategory.Id == id)
                .FirstOrDefaultAsync();

            return serviceCategory;
        }

        public override async Task<ICollection<ServiceCategory>> GetById(ICollection<int> ids)
        {
            var serviceCategory = await applicationDbContext.ServiceCategories
                .Where(serviceCategory => !serviceCategory.IsDeleted)
                .Where(serviceCategory => ids.Contains(serviceCategory.Id))
                .ToListAsync();

            return serviceCategory;
        }
    }
}