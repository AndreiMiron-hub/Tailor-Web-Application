using AutoMapper;
using TailorWebApp.Application.Dtos.Orders.ServiceCategory;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;

namespace TailorWebApp.Application.Services.Orders
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IServiceCategoryRepository serviceCategoryRepository;
        private readonly IMapper mapper;

        public ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository,
            IMapper mapper)
        {
            this.serviceCategoryRepository = serviceCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseServiceCategoryDto> Create(ServiceCategoryDto serviceCategoryDto)
        {
            var entity = mapper.Map<ServiceCategory>(serviceCategoryDto);
            var serviceCategory = await serviceCategoryRepository.Create(entity);

            return mapper.Map<ResponseServiceCategoryDto>(serviceCategory);
        }

        public async Task<ICollection<ResponseServiceCategoryDto>> GetAll()
        {
            var serviceCategories = await serviceCategoryRepository.GetAll();

            return mapper.Map<ICollection<ResponseServiceCategoryDto>>(serviceCategories);
        }

        public async Task<ResponseServiceCategoryDto> GetById(int id)
        {
            var serviceCategory = await serviceCategoryRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseServiceCategoryDto>(serviceCategory);
        }

        public async Task<ICollection<ResponseServiceCategoryDto>> GetById(ICollection<int> ids)
        {
            var serviceCategories = await serviceCategoryRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseServiceCategoryDto>>(serviceCategories);
        }

        public async Task<ResponseServiceCategoryDto> Update(int id, ServiceCategoryDto serviceCategoryDto)
        {
            var serviceCategory = await serviceCategoryRepository.GetById(id) ?? throw new Exception();

            mapper.Map(serviceCategoryDto, serviceCategory);

            await serviceCategoryRepository.Update(serviceCategory);

            return mapper.Map<ResponseServiceCategoryDto>(serviceCategory);
        }

        public async Task Delete(int id)
        {
            var serviceCategory = await serviceCategoryRepository.GetById(id) ?? throw new Exception();

            await serviceCategoryRepository.Delete(serviceCategory);
        }
    }
}