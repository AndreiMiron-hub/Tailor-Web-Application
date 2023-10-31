using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Configurations.Products
{
    public class ProductTagConfiguration : BaseEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            base.Configure(builder);

            builder.Property(productTag => productTag.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}