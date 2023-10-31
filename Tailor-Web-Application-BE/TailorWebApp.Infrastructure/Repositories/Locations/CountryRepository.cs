using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Infrastructure.Data;
using TailorWebApp.Infrastructure.Repositories.Base;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;

namespace TailorWebApp.Infrastructure.Repositories.Locations
{
    public class CountryRepository : BaseEntityRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<Country> Create(Country entity)
        {
            await dbSet.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();

            return await GetById(entity.Id);
        }

        public override async Task<ICollection<Country>> GetAll()
        {
            var countries = await applicationDbContext.Countries
                .Where(country => !country.IsDeleted)
                .Include(country => country.Region)
                .ToListAsync();

            return countries;
        }

        public override async Task<Country?> GetById(Guid id)
        {
            var country = await applicationDbContext.Countries
                .Where(country => !country.IsDeleted)
                .Where(country => country.Id == id)
                .Include(country => country.Region)
                .FirstOrDefaultAsync();

            return country;
        }

        public override async Task<ICollection<Country>> GetById(ICollection<Guid> ids)
        {
            var countries = await applicationDbContext.Countries
                .Where(country => !country.IsDeleted)
                .Where(country => ids.Contains(country.Id))
                .ToListAsync();

            return countries;
        }
    }
}