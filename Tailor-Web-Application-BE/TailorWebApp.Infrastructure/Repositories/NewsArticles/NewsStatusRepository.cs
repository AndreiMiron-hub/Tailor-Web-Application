using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.NewsArticles
{
    public class NewsStatusRepository : BaseEnumEntityRepository<NewsStatus>, INewsStatusRepository
    {
        public NewsStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}