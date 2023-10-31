using TailorWebApp.Application.Dtos.Products.ProductStatus;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductStatusService
    {
        Task<ResponseProductStatusDto> Create(ProductStatusDto productStatusDto);

        Task<ICollection<ResponseProductStatusDto>> GetAll();

        Task<ResponseProductStatusDto> GetById(int id);

        Task<ICollection<ResponseProductStatusDto>> GetById(ICollection<int> ids);

        Task<ResponseProductStatusDto> Update(int id, ProductStatusDto productStatusDto);

        Task Delete(int id);
    }
}