using TailorWebApp.Domain.Entities.StaffRelated;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Staff.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Staff
{
    public class StaffScheduleRepository : BaseEntityRepository<StaffSchedule>, IStaffScheduleRepository
    {
        public StaffScheduleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}