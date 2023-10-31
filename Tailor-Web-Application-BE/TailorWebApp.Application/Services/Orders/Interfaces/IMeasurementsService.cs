using TailorWebApp.Application.Dtos.Orders.Measurement;

namespace TailorWebApp.Application.Services.Orders.Interfaces
{
    public interface IMeasurementsService
    {
        Task<ResponseMeasurementDto> Create(MeasurementDto measurementDto);

        Task<ICollection<ResponseMeasurementDto>> GetAll();

        Task<ResponseMeasurementDto> GetById(Guid id);

        Task<ICollection<ResponseMeasurementDto>> GetById(ICollection<Guid> ids);

        Task<ResponseMeasurementDto> Update(Guid id, MeasurementDto measurementDto);

        Task Delete(Guid id);
    }
}