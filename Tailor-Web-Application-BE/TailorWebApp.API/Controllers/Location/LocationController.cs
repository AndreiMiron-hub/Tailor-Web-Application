using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Locations.Location;
using TailorWebApp.Application.Services.Locations.Interfaces;

namespace TailorWebApp.BE.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationDto locationDto)
        {
            var location = await locationService.Create(locationDto);

            return Ok(location);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await locationService.GetAll();

            return Ok(locations);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var location = await locationService.GetById(id);

            return Ok(location);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var locations = await locationService.GetById(ids);

            return Ok(locations);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, LocationDto locationDto)
        {
            var locations = await locationService.Update(id, locationDto);

            return Ok(locations);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await locationService.Delete(id);

            return Ok(id);
        }
    }
}