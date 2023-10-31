using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Orders.ServiceCategory;
using TailorWebApp.Application.Services.Orders.Interfaces;

namespace TailorWebApp.BE.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            this.serviceCategoryService = serviceCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceCategoryDto serviceCategoryDto)
        {
            var serviceCategory = await serviceCategoryService.Create(serviceCategoryDto);

            return Ok(serviceCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceCategories = await serviceCategoryService.GetAll();

            return Ok(serviceCategories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceCategory = await serviceCategoryService.GetById(id);

            return Ok(serviceCategory);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var serviceCategories = await serviceCategoryService.GetById(ids);

            return Ok(serviceCategories);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ServiceCategoryDto serviceCategoryDto)
        {
            var serviceCategories = await serviceCategoryService.Update(id, serviceCategoryDto);

            return Ok(serviceCategories);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await serviceCategoryService.Delete(id);

            return Ok(id);
        }
    }
}