namespace TailorWebApp.Utils.Dtos
{
    public record ErrorResponseDto
    {
        public IReadOnlyDictionary<string, string>? Errors { get; set; }
        public string? Exception { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}