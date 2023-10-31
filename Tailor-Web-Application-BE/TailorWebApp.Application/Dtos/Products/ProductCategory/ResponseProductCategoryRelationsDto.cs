using TailorWebApp.Application.Dtos.Products.ProductTypes;

namespace TailorWebApp.Application.Dtos.Products.ProductCategory
{
    public class ResponseProductCategoryRelationsDto : ResponseProductCategoryDto
    {
        public ICollection<ResponseProductTypeRelationsDto> ProductTypes { get; set; } = new List<ResponseProductTypeRelationsDto>();
    }
}