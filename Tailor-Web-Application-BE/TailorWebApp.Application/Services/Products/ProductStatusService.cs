using AutoMapper;
using TailorWebApp.Application.Dtos.Products.ProductStatus;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductStatusService : IProductStatusService
    {
        private readonly IProductStatusRepository productStatusRepository;
        private readonly IMapper mapper;

        public ProductStatusService(IProductStatusRepository productStatusRepository,
            IMapper mapper)
        {
            this.productStatusRepository = productStatusRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseProductStatusDto> Create(ProductStatusDto productStatusDto)
        {
            var entity = mapper.Map<ProductStatus>(productStatusDto);
            var productStatus = await productStatusRepository.Create(entity);

            return mapper.Map<ResponseProductStatusDto>(productStatus);
        }

        public async Task<ICollection<ResponseProductStatusDto>> GetAll()
        {
            var productStatuss = await productStatusRepository.GetAll();

            return mapper.Map<ICollection<ResponseProductStatusDto>>(productStatuss);
        }

        public async Task<ResponseProductStatusDto> GetById(int id)
        {
            var productStatus = await productStatusRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ResponseProductStatusDto>(productStatus);
        }

        public async Task<ICollection<ResponseProductStatusDto>> GetById(ICollection<int> ids)
        {
            var productStatus = await productStatusRepository.GetById(ids) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ICollection<ResponseProductStatusDto>>(productStatus);
        }

        public async Task<ResponseProductStatusDto> Update(int id, ProductStatusDto productStatusDto)
        {
            var productStatus = await productStatusRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            mapper.Map(productStatusDto, productStatus);
            await productStatusRepository.Update(productStatus);

            return mapper.Map<ResponseProductStatusDto>(productStatus);
        }

        public async Task Delete(int id)
        {
            var productStatus = await productStatusRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            await productStatusRepository.Delete(productStatus);
        }
    }
}