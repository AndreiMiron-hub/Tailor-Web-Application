using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Products.Interfaces
{
    public interface IProductRepository : IBaseEntityRepository<Product>
    {
        Task<ICollection<Product>> GetFiltered(ProductFilter productFilter, PaginationFilter paginationFilter);
    }
}