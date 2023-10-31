using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.NewsArticles
{
    public class NewsRepository : BaseEntityRepository<News>, INewsRepository
    {
        public NewsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<News> Create(News entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public override async Task<ICollection<News>> GetAll()
        {
            var x=  await dbSet.Where(news => news.IsDeleted == false)
                .Include(news => news.NewsStatus)
                .ToListAsync();

            return x;
        }

        public override async Task<News?> GetById(Guid id)
        {
            var news = await applicationDbContext.News
                .Where(news => !news.IsDeleted)
                .Where(news => news.Id == id)
                .Include(news => news.NewsStatus)
                .FirstOrDefaultAsync();

            return news;
        }

        public override async Task<ICollection<News>> GetById(ICollection<Guid> ids)
        {
            var news = await applicationDbContext.News
                .Where(news => !news.IsDeleted)
                .Where(news => ids.Contains(news.Id))
                .Include(news => news.NewsStatus)
                .ToListAsync();

            return news;
        }
    }
}