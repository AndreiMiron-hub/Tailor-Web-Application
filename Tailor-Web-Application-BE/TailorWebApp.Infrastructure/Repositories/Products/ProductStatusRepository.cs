using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductStatusRepository : BaseEnumEntityRepository<ProductStatus>, IProductStatusRepository
    {
        public ProductStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}