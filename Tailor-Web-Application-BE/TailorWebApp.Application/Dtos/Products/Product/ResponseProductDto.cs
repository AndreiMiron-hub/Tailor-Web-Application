using TailorWebApp.Application.Dtos.Products.ProductCategory;
using TailorWebApp.Application.Dtos.Products.ProductSize;
using TailorWebApp.Application.Dtos.Products.ProductStatus;
using TailorWebApp.Application.Dtos.Products.ProductTags;

namespace TailorWebApp.Application.Dtos.Products.Product
{
    public class ResponseProductDto : BaseProductDto
    {
        public Guid Id { get; set; }
        public ResponseProductCategoryDto Category { get; set; }
        public ResponseProductSizeDto Size { get; set; }
        public ResponseProductStatusDto Status { get; set; }
        public ICollection<ResponseProductTagDto> ProductTags { get; set; } = new List<ResponseProductTagDto>();
    }
}