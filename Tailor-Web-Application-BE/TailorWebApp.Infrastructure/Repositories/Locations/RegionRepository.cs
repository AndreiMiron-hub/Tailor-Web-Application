using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Locations
{
    public class RegionRepository : BaseEnumEntityRepository<Region>, IRegionRepository
    {
        public RegionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}