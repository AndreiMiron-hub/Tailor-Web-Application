using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Configurations.Products
{
    public class ProductStatusConfiguration : BaseEnumEntityConfiguration<ProductStatus>
    {
        public override void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            base.Configure(builder);

            builder.Property(productStatus => productStatus.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}