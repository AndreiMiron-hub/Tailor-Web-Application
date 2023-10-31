using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Locations;

namespace TailorWebApp.Domain.Configurations.Locations
{
    public class RegionConfiguration : BaseEnumEntityConfiguration<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);

            builder.Property(region => region.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}