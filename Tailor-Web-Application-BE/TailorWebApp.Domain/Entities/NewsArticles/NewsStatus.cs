using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.NewsArticles
{
    public record NewsStatus : BaseEnumEntity
    {
        public string Name { get; set; }
        public List<News>? News { get; set; }
    }
}