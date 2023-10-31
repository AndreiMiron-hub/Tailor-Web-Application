using AutoMapper;
using TailorWebApp.Application.Dtos.Products.ProductCategory;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
            IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseProductCategoryRelationsDto> Create(ProductCategoryDto productCategoryDto)
        {
            var entity = mapper.Map<ProductCategory>(productCategoryDto);
            var productCategory = await productCategoryRepository.Create(entity);

            return mapper.Map<ResponseProductCategoryRelationsDto>(productCategory);
        }

        public async Task<ICollection<ResponseProductCategoryRelationsDto>> GetAll()
        {
            var productCategories = await productCategoryRepository.GetAll();

            return mapper.Map<ICollection<ResponseProductCategoryRelationsDto>>(productCategories);
        }

        public async Task<ResponseProductCategoryRelationsDto> GetById(int id)
        {
            var productCategory = await productCategoryRepository.GetById(id) ?? throw new Exception(); // exception middleware

            return mapper.Map<ResponseProductCategoryRelationsDto>(productCategory);
        }

        public async Task<ICollection<ResponseProductCategoryRelationsDto>> GetById(ICollection<int> ids)
        {
            var productCategories = await productCategoryRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseProductCategoryRelationsDto>>(productCategories);
        }

        public async Task<ResponseProductCategoryRelationsDto> Update(int id, ProductCategoryDto productCategoryDto)
        {
            var productCategory = await productCategoryRepository.GetById(id) ?? throw new Exception(); // exception middleware

            mapper.Map(productCategoryDto, productCategory);
            await productCategoryRepository.Update(productCategory);

            return mapper.Map<ResponseProductCategoryRelationsDto>(productCategory);
        }

        public async Task Delete(int id)
        {
            var productCategory = await productCategoryRepository.GetById(id) ?? throw new Exception(); // exception middleware

            await productCategoryRepository.Delete(productCategory);
        }
    }
}