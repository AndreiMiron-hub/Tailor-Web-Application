using TailorWebApp.Application.Dtos.Products.ProductSize;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductSizeService
    {
        Task<ResponseProductSizeDto> Create(ProductSizeDto productSizeDto);

        Task<ICollection<ResponseProductSizeDto>> GetAll();

        Task<ResponseProductSizeDto> GetById(int id);

        Task<ICollection<ResponseProductSizeDto>> GetById(ICollection<int> ids);

        Task<ResponseProductSizeDto> Update(int id, ProductSizeDto productSizeDto);

        Task Delete(int id);
    }
}