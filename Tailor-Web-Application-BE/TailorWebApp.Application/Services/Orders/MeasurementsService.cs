using AutoMapper;
using TailorWebApp.Application.Dtos.Orders.Measurement;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;

namespace TailorWebApp.Application.Services.Orders
{
    public class MeasurementsService : IMeasurementsService
    {
        private readonly IMeasurementsRepository measurementRepository;
        private readonly IMapper mapper;

        public MeasurementsService(IMeasurementsRepository measurementRepository,
            IMapper mapper)
        {
            this.measurementRepository = measurementRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseMeasurementDto> Create(MeasurementDto measurementDto)
        {
            var entity = mapper.Map<Measurement>(measurementDto);
            var measurement = await measurementRepository.Create(entity);

            return mapper.Map<ResponseMeasurementDto>(measurement);
        }

        public async Task<ICollection<ResponseMeasurementDto>> GetAll()
        {
            var measurements = await measurementRepository.GetAll();

            return mapper.Map<ICollection<ResponseMeasurementDto>>(measurements);
        }

        public async Task<ResponseMeasurementDto> GetById(Guid id)
        {
            var measurement = await measurementRepository.GetById(id) ?? throw new KeyNotFoundException();

            return mapper.Map<ResponseMeasurementDto>(measurement);
        }

        public async Task<ICollection<ResponseMeasurementDto>> GetById(ICollection<Guid> ids)
        {
            var measurements = await measurementRepository.GetById(ids);

            return mapper.Map<ICollection<ResponseMeasurementDto>>(measurements);
        }

        public async Task<ResponseMeasurementDto> Update(Guid id, MeasurementDto measurementDto)
        {
            var measurement = await measurementRepository.GetById(id) ?? throw new Exception();

            mapper.Map(measurementDto, measurement);

            await measurementRepository.Update(measurement);

            return mapper.Map<ResponseMeasurementDto>(measurement);
        }

        public async Task Delete(Guid id)
        {
            var measurement = await measurementRepository.GetById(id) ?? throw new Exception();

            await measurementRepository.Delete(measurement);
        }
    }
}