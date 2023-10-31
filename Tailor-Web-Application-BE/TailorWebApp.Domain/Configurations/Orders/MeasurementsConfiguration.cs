using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Configurations.Orders
{
    public class MeasurementsConfiguration : BaseEntityConfiguration<Measurement>
    {
        public override void Configure(EntityTypeBuilder<Measurement> builder)
        {
            base.Configure(builder);

            builder.Property(measurement => measurement.MeasurementName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(measurement => measurement.MeasurementValue)
                .IsRequired();

            builder.HasOne(measurement => measurement.Order)
                .WithMany(order => order.Measurements)
                .HasForeignKey(measurement => measurement.OrderId);
        }
    }
}