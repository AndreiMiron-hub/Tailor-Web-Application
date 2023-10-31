namespace TailorWebApp.Infrastructure.Repositories.Base.Interfaces
{
    public interface IBaseEnumEntityRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);

        Task<ICollection<TEntity>> GetAll();

        Task<TEntity?> GetById(int id);

        Task<ICollection<TEntity>> GetById(ICollection<int> ids);

        Task<ICollection<TEntity>> GetAllByDeletedStatus(bool isDeleted);

        Task<TEntity> Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}