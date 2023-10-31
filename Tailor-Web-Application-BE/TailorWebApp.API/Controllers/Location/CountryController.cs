using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Locations.Country;
using TailorWebApp.Application.Services.Locations.Interfaces;

namespace TailorWebApp.BE.Controllers.Location
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryDto countryDto)
        {
            var country = await countryService.Create(countryDto);

            return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await countryService.GetAll();

            return Ok(countries);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var country = await countryService.GetById(id);

            return Ok(country);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var countries = await countryService.GetById(ids);

            return Ok(countries);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, CountryDto countryDto)
        {
            var countries = await countryService.Update(id, countryDto);

            return Ok(countries);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await countryService.Delete(id);

            return Ok(id);
        }
    }
}