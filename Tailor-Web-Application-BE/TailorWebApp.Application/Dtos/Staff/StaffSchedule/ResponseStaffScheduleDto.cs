namespace TailorWebApp.Application.Dtos.Staff.StaffSchedule
{
    public class ResponseStaffScheduleDto
    {
        public int DayOfTheWeek { get; set; }
        public Guid StaffId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
    }
}