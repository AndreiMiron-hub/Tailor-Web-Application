using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Orders.Measurement;
using TailorWebApp.Application.Services.Orders.Interfaces;

namespace TailorWebApp.BE.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementsService measurementService;

        public MeasurementsController(IMeasurementsService measurementService)
        {
            this.measurementService = measurementService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MeasurementDto measurementDto)
        {
            var measurement = await measurementService.Create(measurementDto);

            return Ok(measurement);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var measurements = await measurementService.GetAll();

            return Ok(measurements);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var measurement = await measurementService.GetById(id);

            return Ok(measurement);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var measurements = await measurementService.GetById(ids);

            return Ok(measurements);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, MeasurementDto measurementDto)
        {
            var measurements = await measurementService.Update(id, measurementDto);

            return Ok(measurements);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await measurementService.Delete(id);

            return Ok(id);
        }
    }
}