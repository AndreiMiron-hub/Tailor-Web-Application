namespace TailorWebApp.Application.Dtos.Orders.Measurement
{
    public class MeasurementDto : BaseMeasurementDto
    {
        public Guid OrderId { get; set; }
    }
}