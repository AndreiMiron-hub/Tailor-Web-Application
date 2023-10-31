using System.Linq.Expressions;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Filters
{
    public class AppointmentFilter
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? OrderId { get; set; }

        public Expression<Func<Appointment, bool>> GetQuery()
        {
            Expression<Func<Appointment, bool>> query = _ => true;

            if (CustomerName is not null)
            {
                query = query.And(appointment => appointment.CustomerName == CustomerName);
            }

            if (CustomerEmail is not null)
            {
                query = query.And(appointment => appointment.CustomerEmail == CustomerEmail);
            }

            if (CustomerPhone is not null)
            {
                query = query.And(appointment => appointment.CustomerPhone == CustomerPhone);
            }

            if (AppointmentDate is not null)
            {
                query = query.And(appointment => appointment.AppointmentDate == AppointmentDate);
            }

            return query;
        }
    }
}