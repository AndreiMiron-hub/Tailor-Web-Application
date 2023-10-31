namespace TailorWebApp.Application.Dtos.NewsArticles
{
    public class ResponseNewsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public List<string> Hashtags { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; }
        public int NewsStatusId { get; set; }
        public string? Image { get; set; }
    }
}
