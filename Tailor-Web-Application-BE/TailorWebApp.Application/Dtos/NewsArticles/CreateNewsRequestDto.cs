namespace TailorWebApp.Application.Dtos.NewsArticles
{
    public class CreateNewsRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public List<string> Hashtags { get; set; }
        public string? Image { get; set; }
        public DateTime? PublishDate { get; set; }
        public int NewsStatusId { get; set; }
    }
}