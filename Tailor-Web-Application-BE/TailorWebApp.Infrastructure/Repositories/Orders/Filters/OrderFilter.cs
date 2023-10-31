using System.Linq.Expressions;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Filters
{
    public class OrderFilter
    {
        public DateTime? EstimatedEndDate { get; set; }
        public float TotalCost { get; set; }
        public int Status { get; set; }
        public string? AsigneeId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ServiceId { get; set; }

        public Expression<Func<Order, bool>> GetQuery()
        {
            Expression<Func<Order, bool>> query = _ => true;

            if (EstimatedEndDate is not null)
            {
                query = query.And(order => order.EstimatedEndDate == EstimatedEndDate);
            }

            if (TotalCost is not 0.0f)
            {
                query = query.And(order => order.TotalCost == TotalCost);
            }

            if (Status is not 0)
            {
                query = query.And(order => order.Status == Status);
            }

            if (AsigneeId is not null)
            {
                query = query.And(order => order.AsigneeId == AsigneeId);
            }

            if (ProductId is not null)
            {
                query = query.And(order => order.ProductId == ProductId);
            }

            if (ServiceId is not null)
            {
                query = query.And(order => order.ServiceId == ServiceId);
            }

            return query;
        }
    }
}