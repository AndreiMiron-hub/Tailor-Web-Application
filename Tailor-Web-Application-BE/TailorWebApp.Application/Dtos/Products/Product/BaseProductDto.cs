namespace TailorWebApp.Application.Dtos.Products.Product
{
    public class BaseProductDto
    {
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Material { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public int Quantity { get; set; }
    }
}