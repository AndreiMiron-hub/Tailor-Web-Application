using TailorWebApp.Application.Dtos.Products.ProductCategory;

namespace TailorWebApp.Application.Dtos.Products.ProductTypes
{
    public class ResponseProductTypeRelationsDto : ResponseProductTypeDto
    {
        public ResponseProductCategoryDto? ProductCategory { get; set; }
    }
}