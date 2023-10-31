using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Configurations.Common
{
    public class BaseEnumEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEnumEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.IsDeleted)
                .IsRequired();
        }
    }
}