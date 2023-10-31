using AutoMapper;
using TailorWebApp.Application.Dtos.Products.ProductTypes;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IMapper mapper;

        public ProductTypeService(IProductTypeRepository productTypeRepository,
            IMapper mapper)
        {
            this.productTypeRepository = productTypeRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseProductTypeDto> Create(ProductTypeDto productTypeDto)
        {
            var entity = mapper.Map<ProductType>(productTypeDto);
            var productType = await productTypeRepository.Create(entity);

            return mapper.Map<ResponseProductTypeDto>(productType);
        }

        public async Task<ICollection<ResponseProductTypeDto>> GetAll()
        {
            var productTypes = await productTypeRepository.GetAll();

            return mapper.Map<ICollection<ResponseProductTypeDto>>(productTypes);
        }

        public async Task<ResponseProductTypeDto> GetById(int id)
        {
            var productType = await productTypeRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ResponseProductTypeDto>(productType);
        }

        public async Task<ICollection<ResponseProductTypeDto>> GetById(ICollection<int> ids)
        {
            var productType = await productTypeRepository.GetById(ids) ?? throw new Exception(); // Exception middleware

            return mapper.Map<ICollection<ResponseProductTypeDto>>(productType);
        }

        public async Task<ResponseProductTypeDto> Update(int id, ProductTypeDto productTypeDto)
        {
            var productType = await productTypeRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            mapper.Map(productTypeDto, productType);
            await productTypeRepository.Update(productType);

            return mapper.Map<ResponseProductTypeDto>(productType);
        }

        public async Task Delete(int id)
        {
            var productType = await productTypeRepository.GetById(id) ?? throw new Exception(); // Exception middleware

            await productTypeRepository.Delete(productType);
        }
    }
}