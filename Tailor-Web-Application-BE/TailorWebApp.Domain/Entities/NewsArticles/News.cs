using TailorWebApp.Domain.Entities.Common;

namespace TailorWebApp.Domain.Entities.NewsArticles
{
    public record News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Hashtags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int NewsStatusId { get; set; }
        public NewsStatus NewsStatus { get; set; }
        public string? Image { get; set; }
    }
}