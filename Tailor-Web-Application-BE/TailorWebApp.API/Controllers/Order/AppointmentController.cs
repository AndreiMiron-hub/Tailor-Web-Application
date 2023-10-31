using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Orders.Appointment;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.BE.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto appointmentDto)
        {
            var appointment = await appointmentService.Create(appointmentDto);

            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await appointmentService.GetAll();

            return Ok(appointments);
        }

        [HttpGet]
        [Route("filters/")]
        public async Task<IActionResult> GetFiltered([FromQuery] AppointmentFilter appointmentFilter, [FromQuery] PaginationFilter paginationFilter)
        {
            var appointments = await appointmentService.GetFiltered(appointmentFilter, paginationFilter);

            return Ok(appointments);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var appointment = await appointmentService.GetById(id);

            return Ok(appointment);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var appointments = await appointmentService.GetById(ids);

            return Ok(appointments);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, AppointmentDto appointmentDto)
        {
            var appointments = await appointmentService.Update(id, appointmentDto);

            return Ok(appointments);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await appointmentService.Delete(id);

            return Ok(id);
        }
    }
}