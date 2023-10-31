using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Products;

namespace TailorWebApp.Domain.Configurations.Products
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(service => service.Image);

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(product => product.Category)
               .WithMany(productCategory => productCategory.Products)
               .HasForeignKey(product => product.CategoryId);

            builder.HasOne(product => product.Size)
                .WithMany(productSize => productSize.Products)
                .HasForeignKey(product => product.SizeId);

            builder.Property(product => product.Color)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(product => product.Material)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(product => product.Price)
                .IsRequired();

            builder.Property(product => product.Description);

            builder.Property(product => product.Quantity)
                .IsRequired();

            builder.HasOne(product => product.Status)
                .WithMany(productStatus => productStatus.Products)
                .HasForeignKey(product => product.StatusId);
        }
    }
}