using AutoMapper;
using TailorWebApp.Application.Dtos.NewsArticles;
using TailorWebApp.Application.Services.AzureStorageService.Interfaces;
using TailorWebApp.Application.Services.NewsArticles.Interfaces;
using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces;
using TailorWebApp.Utils.Constants;

namespace TailorWebApp.Application.Services.NewsArticles
{
    public class NewsService : INewsService
    {
        private readonly IAzureStorageService storageService;
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;
        private readonly INewsStatusRepository newsStatusRepository;

        public NewsService(INewsRepository newsRepository,
            INewsStatusRepository newsStatusRepository,
            IAzureStorageService azureStorageService,
            IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
            this.storageService = azureStorageService;
            this.newsStatusRepository = newsStatusRepository;
        }

        public async Task<ResponseNewsDto> Create(CreateNewsRequestDto newsDto)
        {
            var entity = mapper.Map<News>(newsDto);

            var base64Image = entity.Image;

            var news = await newsRepository.Create(entity);

            entity.Image = await storageService.UploadAsync(base64Image, news.Id.ToString());

            await newsRepository.Update(entity);

            return mapper.Map<ResponseNewsDto>(entity);
        }

        public async Task<ICollection<ResponseNewsDto>> GetAll()
        {
            var news = await newsRepository.GetAll();

            return mapper.Map<ICollection<ResponseNewsDto>>(news);
        }

        public async Task<ResponseNewsDto> GetById(Guid id)
        {
            var news = await newsRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseNewsDto>(news);
        }

        public async Task<ICollection<ResponseNewsDto>> GetByIds(ICollection<Guid> ids)
        {
            var news = await newsRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseNewsDto>>(news);
        }

        public async Task<ResponseNewsDto> Update(Guid id, CreateNewsRequestDto newsDto)
        {
            var news = await newsRepository.GetById(id) ?? throw new KeyNotFoundException();

            mapper.Map(newsDto, news);

            news.NewsStatus = await newsStatusRepository.GetById(newsDto.NewsStatusId);

            var dataToUpload = new List<string>();

            return null;
        }

        public async Task Delete(Guid id)
        {
            var news = await newsRepository.GetById(id);

            if (news is null)
            {
                throw new KeyNotFoundException();
            }

            await storageService.DeleteOccurrencesAsync(id.ToString(), Occurrence.Multiple);

            await newsRepository.Delete(news);
        }
    }
}
