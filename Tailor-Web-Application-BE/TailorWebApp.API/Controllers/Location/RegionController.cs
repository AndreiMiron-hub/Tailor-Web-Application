using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Locations.Region;
using TailorWebApp.Application.Services.Locations.Interfaces;

namespace TailorWebApp.BE.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegionDto regionDto)
        {
            var region = await regionService.Create(regionDto);

            return Ok(region);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var region = await regionService.GetAll();

            return Ok(region);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var region = await regionService.GetById(id);

            return Ok(region);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var regionCategories = await regionService.GetById(ids);

            return Ok(regionCategories);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, RegionDto regionDto)
        {
            var region = await regionService.Update(id, regionDto);

            return Ok(region);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await regionService.Delete(id);

            return Ok(id);
        }
    }
}