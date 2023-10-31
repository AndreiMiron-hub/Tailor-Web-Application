using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Configurations.Orders
{
    public class OfferedServiceConfiguration : BaseEntityConfiguration<OfferedService>
    {
        public override void Configure(EntityTypeBuilder<OfferedService> builder)
        {
            base.Configure(builder);

            builder.Property(service => service.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(service => service.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(service => service.Price)
                .IsRequired();

            builder.Property(service => service.EstDuration)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(service => service.IsAvailable)
                .IsRequired();

            builder.Property(service => service.Images);

            builder.Property(service => service.Discount)
                .IsRequired();

            builder.HasOne(service => service.ServiceCategory)
                .WithMany(serviceCategory => serviceCategory.OfferedServices)
                .HasForeignKey(service => service.ServiceCategoryId);
        }
    }
}