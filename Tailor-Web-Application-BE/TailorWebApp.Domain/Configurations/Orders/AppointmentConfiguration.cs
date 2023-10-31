using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Configurations.Orders
{
    public class AppointmentConfiguration : BaseEntityConfiguration<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);

            builder.Property(appointment => appointment.CustomerName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(appointment => appointment.CustomerEmail)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(appointment => appointment.CustomerPhone)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(appointment => appointment.AppointmentDate)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(appointment => appointment.Notes)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}