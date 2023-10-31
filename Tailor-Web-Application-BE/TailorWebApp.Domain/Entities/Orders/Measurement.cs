using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.Orders
{
    public record Measurement : BaseEntity
    {
        public string MeasurementName { get; set; }
        public float MeasurementValue { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
    }
}