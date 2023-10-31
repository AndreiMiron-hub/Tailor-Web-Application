using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductCategoryRepository : BaseEnumEntityRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<ProductCategory>> GetAll()
        {
            var productCategories = await applicationDbContext.ProductCategories
                .Where(productCategory => !productCategory.IsDeleted)
               .Include(productCategory => productCategory.ProductTypes).IgnoreAutoIncludes()
               .ToListAsync();

            return productCategories;
        }

        public override async Task<ProductCategory?> GetById(int id)
        {
            var productCategory = await applicationDbContext.ProductCategories
                .Where(productCategory => !productCategory.IsDeleted)
                .Where(productCategory => productCategory.Id == id)
                .Include(productCategory => productCategory.ProductTypes)
                .FirstOrDefaultAsync();

            return productCategory;
        }

        public override async Task<ICollection<ProductCategory>> GetById(ICollection<int> ids)
        {
            var productCategories = await applicationDbContext.ProductCategories
                .Where(productCategory => !productCategory.IsDeleted)
                .Where(productCategory => ids.Contains(productCategory.Id))
                .Include(productCategory => productCategory.ProductTypes)
                .ToListAsync();

            return productCategories;
        }
    }
}