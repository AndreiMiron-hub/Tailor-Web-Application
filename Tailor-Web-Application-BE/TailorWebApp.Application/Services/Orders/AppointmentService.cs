using AutoMapper;
using TailorWebApp.Application.Dtos.Orders.Appointment;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository,
            IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseAppointmentDto> Create(AppointmentDto appointmentDto)
        {
            var entity = mapper.Map<Appointment>(appointmentDto);

            var appointment = await appointmentRepository.Create(entity);

            return mapper.Map<ResponseAppointmentDto>(appointment);
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetFiltered(AppointmentFilter appointmentFilter, PaginationFilter paginationFilter)
        {
            var appointments = await appointmentRepository.GetFiltered(appointmentFilter, paginationFilter);

            return mapper.Map<ICollection<ResponseAppointmentDto>>(appointments);
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetAll()
        {
            var appointments = await appointmentRepository.GetAll();

            return mapper.Map<ICollection<ResponseAppointmentDto>>(appointments);
        }

        public async Task<ResponseAppointmentDto> GetById(Guid id)
        {
            var appointment = await appointmentRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseAppointmentDto>(appointment);
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetById(ICollection<Guid> ids)
        {
            var appointments = await appointmentRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseAppointmentDto>>(appointments);
        }

        public async Task<ResponseAppointmentDto> Update(Guid id, AppointmentDto appointmentDto)
        {
            var appointment = await appointmentRepository.GetById(id) ?? throw new KeyNotFoundException();

            mapper.Map(appointmentDto, appointment);

            await appointmentRepository.Update(appointment);

            return mapper.Map<ResponseAppointmentDto>(appointment);
        }

        public async Task Delete(Guid id)
        {
            var appointment = await appointmentRepository.GetById(id) ?? throw new Exception();

            await appointmentRepository.Delete(appointment);
        }
    }
}