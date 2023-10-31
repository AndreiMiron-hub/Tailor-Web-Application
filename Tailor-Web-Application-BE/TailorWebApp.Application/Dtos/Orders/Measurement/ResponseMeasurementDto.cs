using TailorWebApp.Application.Dtos.Orders.Order;

namespace TailorWebApp.Application.Dtos.Orders.Measurement
{
    public class ResponseMeasurementDto : MeasurementDto
    {
        public Guid Id { get; set; }
        public ResponseOrderDto? Order { get; set; }
    }
}