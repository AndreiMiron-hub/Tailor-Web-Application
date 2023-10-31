using TailorWebApp.Application.Dtos.Products.Product;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductService
    {
        Task<ResponseProductDto> Create(ProductDto productDto);

        Task<ICollection<ResponseProductDto>> GetFiltered(ProductFilter productFilter, PaginationFilter paginationFilter);

        Task<ICollection<ResponseProductDto>> GetAll();

        Task<ResponseProductDto> GetById(Guid id);

        Task<ICollection<ResponseProductDto>> GetById(ICollection<Guid> ids);

        Task<ResponseProductDto> Update(Guid id, ProductDto productDto);

        Task Delete(Guid id);
    }
}