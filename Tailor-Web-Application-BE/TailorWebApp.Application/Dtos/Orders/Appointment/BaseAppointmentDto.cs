namespace TailorWebApp.Application.Dtos.Orders.Appointment
{
    public class BaseAppointmentDto
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
    }
}