using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.NewsArticles;

namespace TailorWebApp.Domain.Configurations.NewsArticles
{
    public class NewsStatusConfiguration : BaseEnumEntityConfiguration<NewsStatus>
    {
        public override void Configure(EntityTypeBuilder<NewsStatus> builder)
        {
            base.Configure(builder);

            builder.Property(entity => entity.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}