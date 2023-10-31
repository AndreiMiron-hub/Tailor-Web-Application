using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products.Interfaces
{
    public interface IProductTypeRepository : IBaseEnumEntityRepository<ProductType>
    {
    }
}