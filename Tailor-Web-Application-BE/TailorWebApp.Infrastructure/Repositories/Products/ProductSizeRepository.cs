using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductSizeRepository : BaseEnumEntityRepository<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}