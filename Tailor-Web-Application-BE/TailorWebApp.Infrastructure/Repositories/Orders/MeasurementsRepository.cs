using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Orders
{
    public class MeasurementsRepository : BaseEntityRepository<Measurement>, IMeasurementsRepository
    {
        public MeasurementsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<ICollection<Measurement>> GetAll()
        {
            var measurements = await applicationDbContext.Measurements
                .Where(measurement => !measurement.IsDeleted)
                .Include(measurements => measurements.Order)
                .ToListAsync();

            return measurements;
        }

        public override async Task<Measurement?> GetById(Guid id)
        {
            var measurements = await applicationDbContext.Measurements
                .Where(measurement => !measurement.IsDeleted)
                .Include(measurements => measurements.Order)
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync();

            return measurements;
        }

        public override async Task<ICollection<Measurement>> GetById(ICollection<Guid> ids)
        {
            var measurement = await applicationDbContext.Measurements
                .Where(measurement => !measurement.IsDeleted)
                .Where(measurement => ids.Contains(measurement.Id))
                .Include(measurement => measurement.Order)

                .ToListAsync();

            return measurement;
        }
    }
}