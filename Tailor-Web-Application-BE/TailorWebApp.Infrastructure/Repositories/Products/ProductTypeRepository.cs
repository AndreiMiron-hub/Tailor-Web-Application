using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductTypeRepository : BaseEnumEntityRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<ProductType>> GetAll()
        {
            return await applicationDbContext.ProductTypes
                .Where(productType => !productType.IsDeleted)
                .Include(productType => productType.ProductCategory)
                .ToListAsync();
        }
    }
}