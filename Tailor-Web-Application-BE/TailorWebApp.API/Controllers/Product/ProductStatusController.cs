using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Products.ProductStatus;
using TailorWebApp.Application.Services.Products.Interfaces;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStatusController : ControllerBase
    {
        private readonly IProductStatusService productStatusService;

        public ProductStatusController(IProductStatusService productStatusService)
        {
            this.productStatusService = productStatusService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductStatusDto productStatusDto)
        {
            var productStatus = await productStatusService.Create(productStatusDto);

            return Ok(productStatus);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productStatus = await productStatusService.GetAll();

            return Ok(productStatus);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productStatus = await productStatusService.GetById(id);

            return Ok(productStatus);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var productStatus = await productStatusService.GetById(ids);

            return productStatus.Any() ? Ok(productStatus) : NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProductStatusDto productStatusDto)
        {
            var productStatus = await productStatusService.Update(id, productStatusDto);

            return Ok(productStatus);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await productStatusService.Delete(id);

            return Ok(id);
        }
    }
}