using System.Linq.Expressions;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Products.Filters
{
    public class ProductFilter
    {
        public string? Color { get; set; }
        public string? Material { get; set; }
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        public int StatusId { get; set; }

        public Expression<Func<Product, bool>> GetQuery()
        {
            Expression<Func<Product, bool>> query = _ => true;

            if (Color is not null)
            {
                query = query.And(Product => Product.Color == Color);
            }

            if (Material is not null)
            {
                query = query.And(Product => Product.Material == Material);
            }

            if (CategoryId is not 0)
            {
                query = query.And(Product => Product.CategoryId == CategoryId);
            }

            if (SizeId is not 0)
            {
                query = query.And(Product => Product.SizeId == SizeId);
            }

            if (StatusId is not 0)
            {
                query = query.And(Product => Product.StatusId == StatusId);
            }

            return query;
        }
    }
}