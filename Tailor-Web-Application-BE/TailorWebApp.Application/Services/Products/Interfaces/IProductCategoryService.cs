using TailorWebApp.Application.Dtos.Products.ProductCategory;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ResponseProductCategoryRelationsDto> Create(ProductCategoryDto productCategoryDto);

        Task<ICollection<ResponseProductCategoryRelationsDto>> GetAll();

        Task<ResponseProductCategoryRelationsDto> GetById(int id);

        Task<ICollection<ResponseProductCategoryRelationsDto>> GetById(ICollection<int> ids);

        Task<ResponseProductCategoryRelationsDto> Update(int id, ProductCategoryDto productCategoryDto);

        Task Delete(int id);
    }
}