using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Staff.StaffSchedule;
using TailorWebApp.Application.Services.Staff.Interfaces;

namespace TailorWebApp.BE.Controllers.Staff
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffScheduleController : ControllerBase
    {
        private readonly IStaffScheduleService staffScheduleService;

        public StaffScheduleController(IStaffScheduleService staffScheduleService)
        {
            this.staffScheduleService = staffScheduleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StaffScheduleDto staffScheduleDto)
        {
            var staffSchedule = await staffScheduleService.Create(staffScheduleDto);

            return Ok(staffSchedule);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffSchedules = await staffScheduleService.GetAll();

            return Ok(staffSchedules);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var staffSchedule = await staffScheduleService.GetById(id);

            return Ok(staffSchedule);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var staffSchedules = await staffScheduleService.GetById(ids);

            return Ok(staffSchedules);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, StaffScheduleDto staffScheduleDto)
        {
            var staffSchedules = await staffScheduleService.Update(id, staffScheduleDto);

            return Ok(staffSchedules);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await staffScheduleService.Delete(id);

            return Ok(id);
        }
    }
}