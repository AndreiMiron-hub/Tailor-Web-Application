using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Products.ProductSize;
using TailorWebApp.Application.Services.Products.Interfaces;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeService productSizeService;

        public ProductSizeController(IProductSizeService productSizeService)
        {
            this.productSizeService = productSizeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSizeDto productSizeDto)
        {
            var productSize = await productSizeService.Create(productSizeDto);

            return Ok(productSize);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productSizes = await productSizeService.GetAll();

            return Ok(productSizes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productSize = await productSizeService.GetById(id);

            return Ok(productSize);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var productSize = await productSizeService.GetById(ids);

            return Ok(productSize);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProductSizeDto productSizeDto)
        {
            var productSize = await productSizeService.Update(id, productSizeDto);

            return Ok(productSize);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await productSizeService.Delete(id);

            return Ok(id);
        }
    }
}