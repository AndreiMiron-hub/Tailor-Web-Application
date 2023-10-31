using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Configurations.Orders
{
    public class ServiceCategoriesConfiguration : BaseEnumEntityConfiguration<ServiceCategory>
    {
        public override void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            base.Configure(builder);

            builder.Property(serviceCategory => serviceCategory.CategoryName)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}