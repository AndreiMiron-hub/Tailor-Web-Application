using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Products
{
    public class ProductTagRepository : BaseEntityRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<ProductTag>> GetAll()
        {
            var productTags = await applicationDbContext.ProductTags
                .Where(productTags => !productTags.IsDeleted)
                .Include(productTags => productTags.Products)
                .ToListAsync();

            return productTags;
        }

        public override async Task<ProductTag?> GetById(Guid id)
        {
            var productTags = await applicationDbContext.ProductTags
                .Where(productTags => !productTags.IsDeleted)
                .Where(productTags => id == productTags.Id)
                .Include(productTags => productTags.Products)
                .FirstOrDefaultAsync();

            return productTags;
        }

        public async Task RemoveProductTag(Guid ProductId, Guid TagId)
        {
            var record = await applicationDbContext.ProductTagsJoin
                .Where(pth => pth.TagId == TagId &&
                pth.ProductId == ProductId)
                .FirstOrDefaultAsync();

            applicationDbContext.ProductTagsJoin.Remove(record!);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}