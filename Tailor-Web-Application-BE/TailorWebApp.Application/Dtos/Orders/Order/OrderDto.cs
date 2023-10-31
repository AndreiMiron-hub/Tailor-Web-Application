namespace TailorWebApp.Application.Dtos.Orders.Order
{
    public class OrderDto : BaseOrderDto
    {
        public Guid AsigneeId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ServiceId { get; set; }
    }
}