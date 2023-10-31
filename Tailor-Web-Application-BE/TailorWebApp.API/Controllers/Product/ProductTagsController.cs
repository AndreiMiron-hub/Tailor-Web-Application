using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Products.ProductTags;
using TailorWebApp.Application.Services.Products.Interfaces;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTagsController : ControllerBase
    {
        private readonly IProductTagService productTagService;

        public ProductTagsController(IProductTagService productTagService)
        {
            this.productTagService = productTagService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductTagDto productTagDto)
        {
            var productTag = await productTagService.Create(productTagDto);

            return Ok(productTag);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productTags = await productTagService.GetAll();

            return Ok(productTags);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var productTag = await productTagService.GetById(id);

            return Ok(productTag);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var productTags = await productTagService.GetById(ids);

            return Ok(productTags);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductTagDto productTagDto)
        {
            var productTag = await productTagService.Update(id, productTagDto);

            return Ok(productTag);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await productTagService.Delete(id);

            return Ok(id);
        }
    }
}