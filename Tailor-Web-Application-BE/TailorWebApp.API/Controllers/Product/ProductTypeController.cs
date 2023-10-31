using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Products.ProductTypes;
using TailorWebApp.Application.Services.Products.Interfaces;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductTypeDto productTypeDto)
        {
            var productType = await productTypeService.Create(productTypeDto);

            return Ok(productType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productTypes = await productTypeService.GetAll();

            return Ok(productTypes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productType = await productTypeService.GetById(id);

            return Ok(productType);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var productTypes = await productTypeService.GetById(ids);

            return productTypes.Any() ? Ok(productTypes) : NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProductTypeDto productTypeDto)
        {
            var productType = await productTypeService.Update(id, productTypeDto);

            return Ok(productType);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await productTypeService.Delete(id);

            return Ok(id);
        }
    }
}