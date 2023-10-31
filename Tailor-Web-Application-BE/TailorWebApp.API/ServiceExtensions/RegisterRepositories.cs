using TailorWebApp.Infrastructure.Repositories.Accounts;
using TailorWebApp.Infrastructure.Repositories.Accounts.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Locations;
using TailorWebApp.Infrastructure.Repositories.Locations.Interfaces;
using TailorWebApp.Infrastructure.Repositories.NewsArticles.Interfaces;
using TailorWebApp.Infrastructure.Repositories.NewsArticles;
using TailorWebApp.Infrastructure.Repositories.Orders;
using TailorWebApp.Infrastructure.Repositories.Orders.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Products;
using TailorWebApp.Infrastructure.Repositories.Products.Interfaces;
using TailorWebApp.Infrastructure.Repositories.Staff;
using TailorWebApp.Infrastructure.Repositories.Staff.Interfaces;

namespace TailorWebApp.BE.ServiceExtensions
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddApiRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
            services.AddScoped<IProductTagRepository, ProductTagRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();

            services.AddScoped<IAccountTokenRepository, AccountTokenRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IStaffScheduleRepository, StaffScheduleRepository>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
            services.AddScoped<IOfferedServiceRepository, OfferedServiceRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();

            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsStatusRepository, NewsStatusRepository>();

            return services;
        }
    }
}