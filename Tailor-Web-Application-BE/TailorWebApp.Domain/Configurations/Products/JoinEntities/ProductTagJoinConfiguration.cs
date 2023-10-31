using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Entities.Products.JoinEntities;

namespace TailorWebApp.Domain.Configurations.Products.JoinEntities
{
    public class ProductTagJoinConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductTagJoin> builder)
        {
            builder
                .HasKey(productTagJoin => new { productTagJoin.ProductId, productTagJoin.TagId });

            builder
                .HasOne(productTagJoin => productTagJoin.Product)
                .WithMany(product => product.Tags)
                .HasForeignKey(productTagJoin => productTagJoin.ProductId);

            builder
                .HasOne(productTagJoin => productTagJoin.Tag)
                .WithMany(tag => tag.Products)
                .HasForeignKey(productTagJoin => productTagJoin.TagId);
        }
    }
}