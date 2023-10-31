using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Orders
{
    public class AppointmentRepository : BaseEntityRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<Appointment>> GetAll()
        {
            var appointments = await applicationDbContext.Appointments
                .Where(appointment => !appointment.IsDeleted)
                .ToListAsync();

            return appointments;
        }

        public override async Task<Appointment?> GetById(Guid id)
        {
            var appointments = await applicationDbContext.Appointments
                .Where(appointment => !appointment.IsDeleted)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            return appointments;
        }

        public override async Task<ICollection<Appointment>> GetById(ICollection<Guid> ids)
        {
            var appointment = await applicationDbContext.Appointments
                .Where(appointment => !appointment.IsDeleted)
                .Where(appointment => ids.Contains(appointment.Id))
                .ToListAsync();

            return appointment;
        }

        public async Task<ICollection<Appointment>> GetFiltered(AppointmentFilter appointmentFilters, PaginationFilter paginationFilter)
        {
            return await Get(appointmentFilters.GetQuery(), paginationFilter).ToListAsync();
        }
    }
}