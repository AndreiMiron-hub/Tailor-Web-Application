using TailorWebApp.Application.Dtos.NewsArticles;

namespace TailorWebApp.Application.Services.NewsArticles.Interfaces
{
    public interface INewsStatusService
    {
        Task<ResponseNewsStatusDto> Create(NewsStatusDto newsStatusDto);
        Task<ResponseNewsStatusDto> GetById(int id);
        Task<List<ResponseNewsStatusDto>> GetById(List<int> ids);
        Task<List<ResponseNewsStatusDto>> GetAll();
        Task<ResponseNewsStatusDto> Update(int id, NewsStatusDto newsStatusDto);
        Task Delete(int id);
    }
}
