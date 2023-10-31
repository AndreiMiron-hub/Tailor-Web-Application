namespace TailorWebApp.Application.Dtos.Products.Product
{
    public class ProductDto : BaseProductDto
    {
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        public int StatusId { get; set; }
        public ICollection<Guid> TagIds { get; set; } = new List<Guid>();
    }
}