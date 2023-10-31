using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Orders
{
    public record Appointment : BaseEntity
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
    }
}