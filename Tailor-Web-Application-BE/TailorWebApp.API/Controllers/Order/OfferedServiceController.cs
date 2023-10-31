using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Orders.OfferedService;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.BE.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferedServiceController : ControllerBase
    {
        private readonly IOfferedServiceService offeredServiceService;

        public OfferedServiceController(IOfferedServiceService offeredServiceService)
        {
            this.offeredServiceService = offeredServiceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfferedServiceDto offeredServiceDto)
        {
            var offeredService = await offeredServiceService.Create(offeredServiceDto);

            return Ok(offeredService);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var offeredServices = await offeredServiceService.GetAll();

            return Ok(offeredServices);
        }

        [HttpGet]
        [Route("filters/")]
        public async Task<IActionResult> GetFiltered([FromQuery] ServiceFilter serviceFilter, [FromQuery] PaginationFilter paginationFilter)
        {
            var offeredServices = await offeredServiceService.GetFiltered(serviceFilter, paginationFilter);

            return Ok(offeredServices);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var offeredService = await offeredServiceService.GetById(id);

            return Ok(offeredService);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var offeredServices = await offeredServiceService.GetById(ids);

            return Ok(offeredServices);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, OfferedServiceDto offeredServiceDto)
        {
            var offeredService = await offeredServiceService.Update(id, offeredServiceDto);

            return Ok(offeredService);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await offeredServiceService.Delete(id);

            return Ok(id);
        }
    }
}