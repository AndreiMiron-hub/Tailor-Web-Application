using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.NewsArticles;
using TailorWebApp.Application.Services.NewsArticles.Interfaces;

namespace TailorWebApp.BE.Controllers.NewsArticles
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsStatusController : ControllerBase
    {
        private readonly INewsStatusService newsStatusService;

        public NewsStatusController(INewsStatusService newsStatusService)
        {
            this.newsStatusService = newsStatusService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsStatusDto newsStatusDto)
        {
            var newsStatus = await newsStatusService.Create(newsStatusDto);

            return Ok(newsStatus);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var newsStaus = await newsStatusService.GetById(id);

            return Ok(newsStaus);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetByIds([FromQuery] List<int> id)
        {
            var newsStatus = await newsStatusService.GetById(id);

            return newsStatus.Any() ? Ok(newsStatus) : NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var newsStatus = await newsStatusService.GetAll();

            return Ok(newsStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NewsStatusDto newsStatusDto)
        {
            var newsStatus = await newsStatusService.Update(id, newsStatusDto);

            return Ok(newsStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await newsStatusService.Delete(id);

            return Ok(id);
        }
    }
}