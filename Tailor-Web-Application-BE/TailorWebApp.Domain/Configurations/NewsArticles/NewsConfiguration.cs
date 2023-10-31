using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Configurations.Common;
using TailorWebApp.Domain.Entities.NewsArticles;

namespace TailorWebApp.Domain.Configurations.NewsArticles
{
    public class NewsConfiguration : BaseEntityConfiguration<News>
    {
        public override void Configure(EntityTypeBuilder<News> builder)
        {
            base.Configure(builder);

            builder.HasOne(news => news.NewsStatus)
                .WithMany(newsStatus => newsStatus.News)
                .HasForeignKey(news => news.NewsStatusId);

            builder.Property(entity => entity.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(entity => entity.Description)
                .IsRequired();

            builder.Property(entity => entity.Text)
                .IsRequired();

            builder.Property(entity => entity.Hashtags)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(entity => entity.CreationDate)
                .IsRequired()
                .HasConversion(date => date, date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            builder.Property(entity => entity.PublishDate)
                .IsRequired(false)
                .HasConversion(date => date, date => date.HasValue ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc) : date);

            builder.Property(entity => entity.Image)
                .IsRequired(false);
        }
    }
}