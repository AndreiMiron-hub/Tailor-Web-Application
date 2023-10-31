using AutoMapper;
using TailorWebApp.Application.Dtos.NewsArticles;
using TailorWebApp.Application.Services.NewsArticles.Interfaces;
using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces;

namespace TailorWebApp.Application.Services.NewsArticles
{
    public class NewsStatusService : INewsStatusService
    {
        private readonly INewsStatusRepository newsStatusRepository;
        private readonly IMapper mapper;

        public NewsStatusService(INewsStatusRepository newsStatusRepository, IMapper mapper)
        {
            this.newsStatusRepository = newsStatusRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseNewsStatusDto> Create(NewsStatusDto newsDto)
        {
            var entity = mapper.Map<NewsStatus>(newsDto);
            var newsStatus = await newsStatusRepository.Create(entity);

            return mapper.Map<ResponseNewsStatusDto>(newsStatus);
        }

        public async Task Delete(int id)
        {
            var newsStatus = await newsStatusRepository.GetById(id);

            if (newsStatus is null)
            {
                throw new KeyNotFoundException();
            }

            await newsStatusRepository.Delete(newsStatus);
        }

        public async Task<List<ResponseNewsStatusDto>> GetAll()
        {
            var newsStatus = await newsStatusRepository.GetAll();

            return mapper.Map<List<ResponseNewsStatusDto>>(newsStatus);
        }

        public async Task<ResponseNewsStatusDto> GetById(int id)
        {
            var newsStatus = await newsStatusRepository.GetById(id);

            if (newsStatus is null)
            {
                throw new KeyNotFoundException();
            }

            return mapper.Map<ResponseNewsStatusDto>(newsStatus);
        }

        public async Task<List<ResponseNewsStatusDto>> GetById(List<int> ids)
        {
            var newsStatus = await newsStatusRepository.GetById(ids);

            return mapper.Map<List<ResponseNewsStatusDto>>(newsStatus);
        }

        public async Task<ResponseNewsStatusDto> Update(int id, NewsStatusDto newsStatusDto)
        {
            var newsStatus = await newsStatusRepository.GetById(id);

            if (newsStatus is null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(newsStatusDto, newsStatus);
            await newsStatusRepository.Update(newsStatus);

            return mapper.Map<ResponseNewsStatusDto>(newsStatus);
        }
    }
}
