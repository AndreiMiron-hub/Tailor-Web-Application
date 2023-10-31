using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.StaffRelated
{
    public record StaffSchedule : BaseEntity
    {
        public int DayOfTheWeek { get; set; }
        public Guid StaffId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
    }
}