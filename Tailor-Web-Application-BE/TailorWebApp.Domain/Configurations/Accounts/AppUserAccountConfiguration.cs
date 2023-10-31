using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Entities.Accounts;

namespace TailorWebApp.Domain.Configurations.Accounts
{
    public class AppUserAccountConfiguration : IEntityTypeConfiguration<AppUserAccount>
    {
        public void Configure(EntityTypeBuilder<AppUserAccount> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(50);

            builder.Property(user => user.LastName)
                .HasMaxLength(50);
        }
    }
}