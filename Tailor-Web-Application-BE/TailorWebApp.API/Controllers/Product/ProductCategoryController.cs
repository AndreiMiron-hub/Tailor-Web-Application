using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Products.ProductCategory;
using TailorWebApp.Application.Services.Products.Interfaces;

namespace TailorWebApp.BE.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryDto productCategoryDto)
        {
            var productCategory = await productCategoryService.Create(productCategoryDto);

            return Ok(productCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productCategory = await productCategoryService.GetAll();

            return Ok(productCategory);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productCategory = await productCategoryService.GetById(id);

            return Ok(productCategory);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<int> ids)
        {
            var productCategories = await productCategoryService.GetById(ids);

            return Ok(productCategories);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProductCategoryDto productCategoryDto)
        {
            var productCategory = await productCategoryService.Update(id, productCategoryDto);

            return Ok(productCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await productCategoryService.Delete(id);

            return Ok(id);
        }
    }
}