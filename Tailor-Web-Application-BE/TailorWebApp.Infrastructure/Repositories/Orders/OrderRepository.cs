using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders
{
    public class OrderRepository : BaseEntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<Order>> GetAll()
        {
            var orders = await applicationDbContext.Orders
                .Where(order => !order.IsDeleted)
                .Include(order => order.EmployeeAccount)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Category)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Size)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Status)
                .Include(order => order.Service)
                    .ThenInclude(service => service.ServiceCategory)
                .ToListAsync();

            return orders;
        }

        public override async Task<Order?> GetById(Guid id)
        {
            var orders = await applicationDbContext.Orders
                .Where(order => !order.IsDeleted)
                .Include(order => order.EmployeeAccount)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Category)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Size)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Status)
                .Include(order => order.Service)
                    .ThenInclude(service => service.ServiceCategory)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            return orders;
        }

        public override async Task<ICollection<Order>> GetById(ICollection<Guid> ids)
        {
            var order = await applicationDbContext.Orders
                .Where(order => !order.IsDeleted)
                .Where(order => ids.Contains(order.Id))
                .Include(order => order.EmployeeAccount)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Category)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Size)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Status)
                .Include(order => order.Service)
                    .ThenInclude(service => service.ServiceCategory)
                .ToListAsync();

            return order;
        }

        public async Task<ICollection<Order>> GetFiltered(OrderFilter orderFilter, PaginationFilter paginationFilter)
        {
            return await Get(orderFilter.GetQuery(), paginationFilter)
                .Include(order => order.EmployeeAccount)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Category)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Size)
                .Include(order => order.Product)
                    .ThenInclude(product => product.Status)
                .Include(order => order.Service)
                    .ThenInclude(service => service.ServiceCategory)
                .ToListAsync();
        }
    }
}