using AutoMapper;
using TailorWebApp.Application.Dtos.Staff.StaffSchedule;
using TailorWebApp.Application.Services.Staff.Interfaces;
using TailorWebApp.Domain.Entities.StaffRelated;
using TailorWebApp.Infrastructure.Repositories.Staff.Interfaces;

namespace TailorWebApp.Application.Services.Staff
{
    public class StaffScheduleService : IStaffScheduleService
    {
        private readonly IStaffScheduleRepository staffScheduleRepository;
        private readonly IMapper mapper;

        public StaffScheduleService(IStaffScheduleRepository staffScheduleRepository,
            IMapper mapper)
        {
            this.staffScheduleRepository = staffScheduleRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseStaffScheduleDto> Create(StaffScheduleDto staffScheduleDto)
        {
            var entity = mapper.Map<StaffSchedule>(staffScheduleDto);
            var staffSchedule = await staffScheduleRepository.Create(entity);

            return mapper.Map<ResponseStaffScheduleDto>(staffSchedule);
        }

        public async Task<ICollection<ResponseStaffScheduleDto>> GetAll()
        {
            var staffSchedules = await staffScheduleRepository.GetAll();

            return mapper.Map<ICollection<ResponseStaffScheduleDto>>(staffSchedules);
        }

        public async Task<ResponseStaffScheduleDto> GetById(Guid id)
        {
            var staffSchedule = await staffScheduleRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ResponseStaffScheduleDto>(staffSchedule);
        }

        public async Task<ICollection<ResponseStaffScheduleDto>> GetById(ICollection<Guid> ids)
        {
            var staffSchedule = await staffScheduleRepository.GetById(ids) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ICollection<ResponseStaffScheduleDto>>(staffSchedule);
        }

        public async Task<ResponseStaffScheduleDto> Update(Guid id, StaffScheduleDto staffScheduleDto)
        {
            var staffSchedule = await staffScheduleRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            mapper.Map(staffScheduleDto, staffSchedule);
            await staffScheduleRepository.Update(staffSchedule);

            return mapper.Map<ResponseStaffScheduleDto>(staffSchedule);
        }

        public async Task Delete(Guid id)
        {
            var staffSchedule = await staffScheduleRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            await staffScheduleRepository.Delete(staffSchedule);
        }
    }
}