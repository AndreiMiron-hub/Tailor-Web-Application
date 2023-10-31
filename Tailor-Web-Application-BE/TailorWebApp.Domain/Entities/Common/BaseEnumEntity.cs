namespace TailorWebApp.Domain.Entities.Common
{
    public record BaseEnumEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}