using TailorWebApp.Application.Dtos.Products.ProductTypes;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductTypeService
    {
        Task<ResponseProductTypeDto> Create(ProductTypeDto productTypeDto);

        Task<ICollection<ResponseProductTypeDto>> GetAll();

        Task<ResponseProductTypeDto> GetById(int id);

        Task<ICollection<ResponseProductTypeDto>> GetById(ICollection<int> ids);

        Task<ResponseProductTypeDto> Update(int id, ProductTypeDto productTypeDto);

        Task Delete(int id);
    }
}