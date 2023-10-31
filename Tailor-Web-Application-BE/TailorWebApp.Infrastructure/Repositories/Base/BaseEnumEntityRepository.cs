using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Common;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Base
{
    public class BaseEnumEntityRepository<TEntity> : IBaseEnumEntityRepository<TEntity> where TEntity : BaseEnumEntity
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseEnumEntityRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await dbSet.Where(entity => !entity.IsDeleted)
                .ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllByDeletedStatus(bool isDeleted)
        {
            return await dbSet
                .Where(entity => !entity.IsDeleted)
                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetById(ICollection<int> ids)
        {
            return await dbSet
                .Where(entity => ids.Contains(entity.Id))
                .ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            dbSet.Update(entity);
            await applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            await applicationDbContext.SaveChangesAsync();
        }
    }
}