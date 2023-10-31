using TailorWebApp.Application.Dtos.Orders.Appointment;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders.Interfaces
{
    public interface IAppointmentService
    {
        Task<ResponseAppointmentDto> Create(AppointmentDto appointmentDto);

        Task<ICollection<ResponseAppointmentDto>> GetFiltered(AppointmentFilter appointmentFilter, PaginationFilter paginationFilter);

        Task<ICollection<ResponseAppointmentDto>> GetAll();

        Task<ResponseAppointmentDto> GetById(Guid id);

        Task<ICollection<ResponseAppointmentDto>> GetById(ICollection<Guid> ids);

        Task<ResponseAppointmentDto> Update(Guid id, AppointmentDto appointmentDto);

        Task Delete(Guid id);
    }
}