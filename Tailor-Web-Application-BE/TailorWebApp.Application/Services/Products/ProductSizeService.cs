using AutoMapper;
using TailorWebApp.Application.Dtos.Products.ProductSize;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductSizeService : IProductSizeService
    {
        private readonly IProductSizeRepository productSizeRepository;
        private readonly IMapper mapper;

        public ProductSizeService(IProductSizeRepository productSizeRepository,
            IMapper mapper)
        {
            this.productSizeRepository = productSizeRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseProductSizeDto> Create(ProductSizeDto productSizeDto)
        {
            var entity = mapper.Map<ProductSize>(productSizeDto);
            var productsize = await productSizeRepository.Create(entity);

            return mapper.Map<ResponseProductSizeDto>(productsize);
        }

        public async Task<ICollection<ResponseProductSizeDto>> GetAll()
        {
            var productSizes = await productSizeRepository.GetAll();

            return mapper.Map<ICollection<ResponseProductSizeDto>>(productSizes);
        }

        public async Task<ResponseProductSizeDto> GetById(int id)
        {
            var productSize = await productSizeRepository.GetById(id) ?? throw new Exception(); // exception middleware

            return mapper.Map<ResponseProductSizeDto>(productSize);
        }

        public async Task<ICollection<ResponseProductSizeDto>> GetById(ICollection<int> ids)
        {
            var productSizes = await productSizeRepository.GetById(ids) ?? throw new Exception(); // exception middleware

            return mapper.Map<ICollection<ResponseProductSizeDto>>(productSizes);
        }

        public async Task<ResponseProductSizeDto> Update(int id, ProductSizeDto productSizeDto)
        {
            var productSize = await productSizeRepository.GetById(id) ?? throw new Exception(); // exception middleware

            mapper.Map(productSizeDto, productSize);
            await productSizeRepository.Update(productSize);

            return mapper.Map<ResponseProductSizeDto>(productSize);
        }

        public async Task Delete(int id)
        {
            var productSize = await productSizeRepository.GetById(id) ?? throw new Exception(); // exception middleware

            await productSizeRepository.Delete(productSize);
        }
    }
}