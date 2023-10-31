namespace TailorWebApp.Application.Dtos.NewsArticles
{
    public class NewsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Hashtags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int NewsStatusId { get; set; }
    }
}