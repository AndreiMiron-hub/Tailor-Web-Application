using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.StaffRelated;

namespace TailorWebApp.Domain.Configurations.Staff
{
    public class StaffScheduleConfiguration : BaseEntityConfiguration<StaffSchedule>
    {
        public override void Configure(EntityTypeBuilder<StaffSchedule> builder)
        {
            base.Configure(builder);

            builder.Property(staffSchedule => staffSchedule.DayOfTheWeek)
                .IsRequired();

            builder.Property(staffSchedule => staffSchedule.StaffId)
                .IsRequired();

            builder.Property(entity => entity.StartTime)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(entity => entity.EndTime)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(entity => entity.BreakStartTime)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(entity => entity.BreakEndTime)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));
        }
    }
}