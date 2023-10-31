using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Configurations.Products
{
    public class ProductSizeConfiguration : BaseEnumEntityConfiguration<ProductSize>
    {
        public override void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            base.Configure(builder);

            builder.Property(productSize => productSize.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}