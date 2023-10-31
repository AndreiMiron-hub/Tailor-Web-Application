using Microsoft.AspNetCore.Mvc;
using TailorWebApp.Application.Dtos.Orders.Order;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.BE.Controllers.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            var order = await orderService.Create(orderDto);

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await orderService.GetAll();

            return Ok(orders);
        }

        [HttpGet]
        [Route("filters/")]
        public async Task<IActionResult> GetFiltered([FromQuery] OrderFilter orderFilter, [FromQuery] PaginationFilter paginationFilter)
        {
            var products = await orderService.GetFiltered(orderFilter, paginationFilter);

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await orderService.GetById(id);

            return Ok(order);
        }

        [HttpGet]
        [Route("ids/")]
        public async Task<IActionResult> GetById([FromQuery] ICollection<Guid> ids)
        {
            var orders = await orderService.GetById(ids);

            return Ok(orders);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, OrderDto orderDto)
        {
            var orders = await orderService.Update(id, orderDto);

            return Ok(orders);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await orderService.Delete(id);

            return Ok(id);
        }
    }
}