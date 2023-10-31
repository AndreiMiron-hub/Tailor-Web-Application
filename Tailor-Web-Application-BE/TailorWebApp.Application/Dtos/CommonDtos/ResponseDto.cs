namespace TailorWebApp.Application.Dtos.CommonDtos
{
    public class ResponseDto<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Records { get; set; } = Enumerable.Empty<TEntity>();
    }
}