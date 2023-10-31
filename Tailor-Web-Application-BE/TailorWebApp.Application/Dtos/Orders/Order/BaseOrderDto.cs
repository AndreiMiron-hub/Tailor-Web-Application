namespace TailorWebApp.Application.Dtos.Orders.Order
{
    public class BaseOrderDto
    {
        public string? ManufacturingDetails { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public float? TotalCost { get; set; }
        public int Status { get; set; }
    }
}