using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces
{
    public interface INewsStatusRepository : IBaseEnumEntityRepository<NewsStatus>
    {
    }
}