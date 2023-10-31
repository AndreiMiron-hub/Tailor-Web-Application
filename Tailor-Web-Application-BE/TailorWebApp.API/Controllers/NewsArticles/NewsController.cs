using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.NewsArticles;
using TailorWebApp.Application.Services.NewsArticles.Interfaces;

namespace TailorWebApp.BE.Controllers.NewsArticles
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsRequestDto newsDto)
        {
            var response = await newsService.Create(newsDto);

            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await newsService.GetAll();

            return Ok(news);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var news = await newsService.GetById(id);

            return Ok(news);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetByIds([FromQuery] ICollection<Guid> ids)
        {
            var news = await newsService.GetByIds(ids);

            return Ok(news);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateNewsRequestDto newsDto)
        {
            var news = await newsService.Update(id, newsDto);

            return Ok(news);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await newsService.Delete(id);

            return Ok(id);
        }
    }
}