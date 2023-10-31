using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Configurations.Products
{
    public class ProductTypeConfiguration : BaseEnumEntityConfiguration<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            base.Configure(builder);

            builder.Property(productType => productType.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(productType => productType.ProductCategory)
                .WithMany(productCategory => productCategory.ProductTypes)
                .HasForeignKey(productType => productType.ProductCategoryId);
        }
    }
}