using AutoMapper;
using TailorWebApp.Application.Dtos.Products.Product;
using TailorWebApp.Application.Services.AzureStorageService.Interfaces;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Domain.Entities.Products.JoinEntities;
using TailorWebApp.Infrastructure.Repositories.Products.Filters;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;
using TailorWebApp.Utils.Constants;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IAzureStorageService storageService;
        private readonly IProductRepository productRepository;
        private readonly IProductTagRepository productTagRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository,
            IProductTagRepository productTagRepository,
            IAzureStorageService azureStorageService,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.productTagRepository = productTagRepository;
            this.storageService = azureStorageService;
            this.mapper = mapper;
        }

        public async Task<ResponseProductDto> Create(ProductDto productDto)
        {
            var entity = mapper.Map<Product>(productDto);
            
            var base64Image = entity.Image;

            entity.Image = string.Empty;

            var product = await productRepository.Create(entity);

            entity.Image = await storageService.UploadAsync(base64Image, product.Id.ToString());

            await productRepository.Update(entity);

            return mapper.Map<ResponseProductDto>(await productRepository.GetById(product.Id));
        }

        public async Task<ICollection<ResponseProductDto>> GetFiltered(ProductFilter productFilter, PaginationFilter paginationFilter)
        {
            var products = await productRepository.GetFiltered(productFilter, paginationFilter);

            return mapper.Map<ICollection<ResponseProductDto>>(products);
        }

        public async Task<ICollection<ResponseProductDto>> GetAll()
        {
            var products = await productRepository.GetAllAsync();

            return mapper.Map<List<ResponseProductDto>>(products);
        }

        public async Task<ResponseProductDto> GetById(Guid id)
        {
            var product = await productRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseProductDto>(product);
        }

        public async Task<ICollection<ResponseProductDto>> GetById(ICollection<Guid> ids)
        {
            var products = await productRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseProductDto>>(products);
        }

        public async Task<ResponseProductDto> Update(Guid id, ProductDto productDto)
        {
            var product = await productRepository.GetById(id) ?? throw new Exception();

            mapper.Map(productDto, product);

            await productRepository.Update(product);

            return mapper.Map<ResponseProductDto>(product);
        }

        public async Task Delete(Guid id)
        {
            var product = await productRepository.GetById(id) ?? throw new Exception();

            await storageService.DeleteOccurrencesAsync(id.ToString(), Occurrence.One);

            await productRepository.Delete(product);
        }
    }
}