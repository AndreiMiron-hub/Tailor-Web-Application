using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Infrastructure.Repositories.Base.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Orders.Interfaces
{
    public interface IMeasurementsRepository : IBaseEntityRepository<Measurement>
    {
    }
}