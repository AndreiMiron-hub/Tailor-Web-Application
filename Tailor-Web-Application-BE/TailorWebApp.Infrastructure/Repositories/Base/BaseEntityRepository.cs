using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailorWebApp.Domain.Entities.Common;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Infrastructure.Repositories.Base
{
    public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseEntityRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            dbSet = applicationDbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            try
            {
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await dbSet.Where(entity => !entity.IsDeleted)
                .ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
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

        public virtual async Task<TEntity?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetById(ICollection<Guid> ids)
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

        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, PaginationFilter paginationFilter, Expression<Func<TEntity, object>> orderBy = null)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            query = query.Where(entity => !entity.IsDeleted);
            query = filter != null ? query.Where(filter) : query;
            query = orderBy != null ? query.OrderBy(orderBy) : query;
            query = paginationFilter != null ? query.Skip(paginationFilter.Offset).Take(paginationFilter.PageSize) : query;

            return query;
        }
    }
}