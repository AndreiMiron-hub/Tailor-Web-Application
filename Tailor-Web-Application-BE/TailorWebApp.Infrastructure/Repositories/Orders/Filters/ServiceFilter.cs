using System.Linq.Expressions;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Filters
{
    public class ServiceFilter
    {
        public float Price { get; set; }
        public bool? IsAvailable { get; set; }
        public float Discount { get; set; }
        public int ServiceCategoryId { get; set; }

        public Expression<Func<OfferedService, bool>> GetQuery()
        {
            Expression<Func<OfferedService, bool>> query = _ => true;

            if (Price is not 0.0f)
            {
                query = query.And(service => service.Price == Price);
            }

            if (IsAvailable is not null)
            {
                query = query.And(service => service.IsAvailable == IsAvailable);
            }

            if (Discount is not 0.0f)
            {
                query = query.And(service => service.Discount == Discount);
            }

            if (ServiceCategoryId is not 0)
            {
                query = query.And(service => service.ServiceCategoryId == ServiceCategoryId);
            }

            return query;
        }
    }
}