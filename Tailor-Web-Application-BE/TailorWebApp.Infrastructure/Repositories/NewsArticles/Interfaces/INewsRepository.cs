using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces
{
    public interface INewsRepository : IBaseEntityRepository<News>
    {
    }
}