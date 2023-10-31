using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.Orders;

namespace TailorWebApp.Domain.Configurations.Orders
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property(order => order.ManufacturingDetails)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(order => order.EstimatedEndDate)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(order => order.TotalCost);

            builder.Property(order => order.Status)
                .IsRequired();

            builder.HasOne(order => order.EmployeeAccount)
                .WithMany(empAcc => empAcc.Orders)
                .HasForeignKey(order => order.AsigneeId);

            builder.HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId);

            builder.HasOne(order => order.Service)
                .WithMany(service => service.Orders)
                .HasForeignKey(order => order.ServiceId);
        }
    }
}