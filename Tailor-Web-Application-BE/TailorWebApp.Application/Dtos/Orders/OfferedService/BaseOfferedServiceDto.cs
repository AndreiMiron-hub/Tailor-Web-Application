namespace TailorWebApp.Application.Dtos.Orders.OfferedService
{
    public class BaseOfferedServiceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? EstDuration { get; set; }
        public bool IsAvailable { get; set; }
        public string? Images { get; set; }
        public float Discount { get; set; }
    }
}