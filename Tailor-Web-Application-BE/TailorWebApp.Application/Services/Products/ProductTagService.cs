using AutoMapper;
using TailorWebApp.Application.Dtos.Products.ProductTags;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductTagService : IProductTagService
    {
        private readonly IProductTagRepository productTagRepository;
        private readonly IMapper mapper;

        public ProductTagService(IProductTagRepository productTagRepository,
            IMapper mapper)
        {
            this.productTagRepository = productTagRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseProductTagDto> Create(ProductTagDto productTagDto)
        {
            var entity = mapper.Map<ProductTag>(productTagDto);
            var productTag = await productTagRepository.Create(entity);

            return mapper.Map<ResponseProductTagDto>(productTag);
        }

        public async Task<ICollection<ResponseProductTagDto>> GetAll()
        {
            var productTags = await productTagRepository.GetAll();

            return mapper.Map<ICollection<ResponseProductTagDto>>(productTags);
        }

        public async Task<ResponseProductTagDto> GetById(Guid id)
        {
            var productTag = await productTagRepository.GetById(id) ?? throw new Exception(); // exception middleware

            return mapper.Map<ResponseProductTagDto>(productTag);
        }

        public async Task<ICollection<ResponseProductTagDto>> GetById(ICollection<Guid> ids)
        {
            var productTags = await productTagRepository.GetById(ids) ?? throw new Exception(); // exception middleware

            return mapper.Map<ICollection<ResponseProductTagDto>>(productTags);
        }

        public async Task<ResponseProductTagDto> Update(Guid id, ProductTagDto productTagDto)
        {
            var productTag = await productTagRepository.GetById(id) ?? throw new Exception(); // exception middleware

            mapper.Map(productTagDto, productTag);
            await productTagRepository.Update(productTag);

            return mapper.Map<ResponseProductTagDto>(productTag);
        }

        public async Task Delete(Guid id)
        {
            var productTag = await productTagRepository.GetById(id) ?? throw new Exception(); // exception middleware

            await productTagRepository.Delete(productTag);
        }
    }
}