using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Locations
{
    public class LocationRepository : BaseEntityRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<Location> Create(Location entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public override async Task<ICollection<Location>> GetAll()
        {
            var locations = await applicationDbContext.Locations
                .Where(location => !location.IsDeleted)
               .Include(location => location.Country)
                    .ThenInclude(country => country.Region)
               .ToListAsync();

            return locations;
        }

        public override async Task<Location?> GetById(Guid id)
        {
            var location = await applicationDbContext.Locations
                .Where(location => !location.IsDeleted)
                .Where(location => location.Id == id)
                .Include(location => location.Country)
                    .ThenInclude(country => country.Region)
                .FirstOrDefaultAsync();

            return location;
        }

        public override async Task<ICollection<Location>> GetById(ICollection<Guid> ids)
        {
            var locations = await applicationDbContext.Locations
                .Where(location => !location.IsDeleted)
                .Where(location => ids.Contains(location.Id))
               .Include(location => location.Country)
                    .ThenInclude(country => country.Region)
               .ToListAsync();

            return locations;
        }
    }
}