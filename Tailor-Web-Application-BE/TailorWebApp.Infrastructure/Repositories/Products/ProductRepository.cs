using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductRepository : BaseEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            var products = await applicationDbContext.Products
                .Where(product => !product.IsDeleted)
                .Include(product => product.Tags)
                .ThenInclude(productTag => productTag.Tag)
                .Include(product => product.Category)
                    .ThenInclude(productCategory => productCategory.ProductTypes)
                .Include(product => product.Size)
                .Include(product => product.Status)
                .ToListAsync();

            return products;
        }

        public override async Task<Product?> GetById(Guid id)
        {
            var product = await applicationDbContext.Products
                .Where(product => !product.IsDeleted)
                .Where(product => product.Id == id)
                .Include(product => product.Tags)
                .ThenInclude(productTag => productTag.Tag)
                .Include(product => product.Category)
                .ThenInclude(productCategory => productCategory.ProductTypes)
                .Include(product => product.Size)
                .Include(product => product.Status)
                .FirstOrDefaultAsync();

            return product;
        }

        public override async Task<ICollection<Product>> GetById(ICollection<Guid> ids)
        {
            var product = await applicationDbContext.Products
                .Where(product => !product.IsDeleted)
                .Where(product => ids.Contains(product.Id))
                .Include(product => product.Tags)
                .ThenInclude(productTag => productTag.Tag)
                .Include(product => product.Category)
                .ThenInclude(productCategory => productCategory.ProductTypes)
                .Include(product => product.Size)
                .Include(product => product.Status)
                .ToListAsync();

            return product;
        }

        public async Task<ICollection<Product>> GetFiltered(ProductFilter productFilter, PaginationFilter paginationFilter)
        {
            return await Get(productFilter.GetQuery(), paginationFilter)
                .Where(product => !product.IsDeleted)
                .Include(product => product.Tags)
                .ThenInclude(productTag => productTag.Tag)
                .Include(product => product.Category)
                .ThenInclude(productCategory => productCategory.ProductTypes)
                .Include(product => product.Size)
                .Include(product => product.Status).ToListAsync();
        }
    }
}