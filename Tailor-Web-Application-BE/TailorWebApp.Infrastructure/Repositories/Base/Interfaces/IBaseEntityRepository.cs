namespace TailorWebApp.Infrastructure.Repositories.Base.Interfaces
{
    public interface IBaseEntityRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);

        Task<ICollection<TEntity>> GetAll();

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetById(Guid id);

        Task<ICollection<TEntity>> GetById(ICollection<Guid> ids);

        Task<ICollection<TEntity>> GetAllByDeletedStatus(bool isDeleted);

        Task<TEntity> Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}