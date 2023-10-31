using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Locations;

namespace TailorWebApp.Domain.Configurations.Locations
{
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(country => country.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(country => country.Region)
                .WithMany(region => region.Countries)
                .HasForeignKey(country => country.Region);
        }
    }
}