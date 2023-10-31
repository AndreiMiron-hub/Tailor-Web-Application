using TailorWebApp.Application.Dtos.NewsArticles;

namespace TailorWebApp.Application.Services.NewsArticles.Interfaces
{
    public interface INewsService
    {
        Task<ResponseNewsDto> Create(CreateNewsRequestDto newsDto);

        Task<ResponseNewsDto> GetById(Guid id);

        Task<ICollection<ResponseNewsDto>> GetByIds(ICollection<Guid> ids);

        Task<ICollection<ResponseNewsDto>> GetAll();

        Task<ResponseNewsDto> Update(Guid id, CreateNewsRequestDto newsDto);

        Task Delete(Guid id);
    }
}