using AutoMapper;
using TailorWebApp.Application.Dtos.Orders.OfferedService;
using TailorWebApp.Application.Services.AzureStorageService.Interfaces;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Filters;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Utils.Constants;
using TailorWebApp.Utils.HelperClasses;

namespace TailorWebApp.Application.Services.Orders
{
    public class OfferedServiceService : IOfferedServiceService
    {
        private readonly IAzureStorageService storageService;
        private readonly IOfferedServiceRepository offeredServiceRepository;
        private readonly IMapper mapper;

        public OfferedServiceService(IOfferedServiceRepository offeredServiceRepository,
            IAzureStorageService azureStorageService,
            IMapper mapper)
        {
            this.offeredServiceRepository = offeredServiceRepository;
            this.storageService = azureStorageService;
            this.mapper = mapper;
        }

        public async Task<ResponseOfferedServiceDto> Create(OfferedServiceDto offeredServiceDto)
        {
            var entity = mapper.Map<OfferedService>(offeredServiceDto);

            var base64Image = entity.Images;

            entity.Images = string.Empty;

            var service = await offeredServiceRepository.Create(entity);

            entity.Images = await storageService.UploadAsync(base64Image, service.Id.ToString());

            await offeredServiceRepository.Update(entity);

            return mapper.Map<ResponseOfferedServiceDto>(service);
        }

        public async Task<ICollection<ResponseOfferedServiceDto>> GetFiltered(ServiceFilter serviceFilter, PaginationFilter paginationFilter)
        {
            var services = await offeredServiceRepository.GetFiltered(serviceFilter, paginationFilter);

            return mapper.Map<ICollection<ResponseOfferedServiceDto>>(services);
        }

        public async Task<ICollection<ResponseOfferedServiceDto>> GetAll()
        {
            var services = await offeredServiceRepository.GetAll();

            return mapper.Map<ICollection<ResponseOfferedServiceDto>>(services);
        }

        public async Task<ResponseOfferedServiceDto> GetById(Guid id)
        {
            var service = await offeredServiceRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseOfferedServiceDto>(service);
        }

        public async Task<ICollection<ResponseOfferedServiceDto>> GetById(ICollection<Guid> ids)
        {
            var services = await offeredServiceRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseOfferedServiceDto>>(services);
        }

        public async Task<ResponseOfferedServiceDto> Update(Guid id, OfferedServiceDto offeredServiceDto)
        {
            var service = await offeredServiceRepository.GetById(id) ?? throw new KeyNotFoundException();

            mapper.Map(offeredServiceDto, service);

            await offeredServiceRepository.Update(service);

            return mapper.Map<ResponseOfferedServiceDto>(service);
        }

        public async Task Delete(Guid id)
        {
            var service = await offeredServiceRepository.GetById(id) ?? throw new Exception();

            await storageService.DeleteOccurrencesAsync(id.ToString(), Occurrence.One);

            await offeredServiceRepository.Delete(service);
        }
    }
}