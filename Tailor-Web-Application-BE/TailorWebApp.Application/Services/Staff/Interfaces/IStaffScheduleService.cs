using TailorWebApp.Application.Dtos.Staff.StaffSchedule;

namespace TailorWebApp.Application.Services.Staff.Interfaces
{
    public interface IStaffScheduleService
    {
        Task<ResponseStaffScheduleDto> Create(StaffScheduleDto staffScheduleDto);

        Task<ICollection<ResponseStaffScheduleDto>> GetAll();

        Task<ResponseStaffScheduleDto> GetById(Guid id);

        Task<ICollection<ResponseStaffScheduleDto>> GetById(ICollection<Guid> ids);

        Task<ResponseStaffScheduleDto> Update(Guid id, StaffScheduleDto staffScheduleDto);

        Task Delete(Guid id);
    }
}