using AutoMapper;
using TailorWebApp.Application.Dtos.Orders.Order;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository,
            IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseOrderDto> Create(OrderDto orderDto)
        {
            var entity = mapper.Map<Order>(orderDto);

            var order = await orderRepository.Create(entity);

            return mapper.Map<ResponseOrderDto>(order);
        }

        public async Task<ICollection<ResponseOrderDto>> GetFiltered(OrderFilter orderFilter, PaginationFilter paginationFilter)
        {
            var orders = await orderRepository.GetFiltered(orderFilter, paginationFilter);

            return mapper.Map<ICollection<ResponseOrderDto>>(orders);
        }

        public async Task<ICollection<ResponseOrderDto>> GetAll()
        {
            var orders = await orderRepository.GetAll();

            return mapper.Map<ICollection<ResponseOrderDto>>(orders);
        }

        public async Task<ResponseOrderDto> GetById(Guid id)
        {
            var order = await orderRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseOrderDto>(order);
        }

        public async Task<ICollection<ResponseOrderDto>> GetById(ICollection<Guid> ids)
        {
            var orders = await orderRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseOrderDto>>(orders);
        }

        public async Task<ResponseOrderDto> Update(Guid id, OrderDto orderDto)
        {
            var order = await orderRepository.GetById(id) ?? throw new KeyNotFoundException();

            mapper.Map(orderDto, order);

            await orderRepository.Update(order);

            return mapper.Map<ResponseOrderDto>(order);
        }

        public async Task Delete(Guid id)
        {
            var order = await orderRepository.GetById(id) ?? throw new KeyNotFoundException();

            await orderRepository.Delete(order);
        }
    }
}