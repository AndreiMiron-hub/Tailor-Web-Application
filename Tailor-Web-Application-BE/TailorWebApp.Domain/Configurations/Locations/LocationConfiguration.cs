using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Locations;

namespace TailorWebApp.Domain.Configurations.Locations
{
    public class LocationConfiguration : BaseEntityConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);

            builder.Property(location => location.StreetAdress)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(location => location.PostalCode)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(location => location.City)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(location => location.Country)
                .WithMany(country => country.Locations)
                .HasForeignKey(location => location.CountryId);
        }
    }
}