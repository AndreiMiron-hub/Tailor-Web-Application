using TailorWebApp.Application.Dtos.Products.ProductTags;

namespace TailorWebApp.Application.Services.Products.Interfaces
{
    public interface IProductTagService
    {
        Task<ResponseProductTagDto> Create(ProductTagDto productTagDto);

        Task<ICollection<ResponseProductTagDto>> GetAll();

        Task<ResponseProductTagDto> GetById(Guid id);

        Task<ICollection<ResponseProductTagDto>> GetById(ICollection<Guid> ids);

        Task<ResponseProductTagDto> Update(Guid id, ProductTagDto productTagDto);

        Task Delete(Guid id);
    }
}