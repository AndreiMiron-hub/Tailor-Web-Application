using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TailorWebApp.Application.Dtos.Authentication;
using TailorWebApp.Application.Dtos.Products.Product;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var product = await productService.Create(productDto);

            return Ok(product);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all product elements")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request successful", Type = typeof(ResponseProductDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid credentials")]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAll();

            return Ok(products);
        }

        [HttpGet]
        [Route("filters/")]
        public async Task<IActionResult> GetFiltered([FromQuery] ProductFilter productFilter, [FromQuery] PaginationFilter paginationFilter)
        {
            var products = await productService.GetFiltered(productFilter, paginationFilter);

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await productService.GetById(id);

            return Ok(product);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var products = await productService.GetById(ids);

            return Ok(products);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductDto productDto)
        {
            var products = await productService.Update(id, productDto);

            return Ok(products);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.Delete(id);

            return Ok(id);
        }
    }
}