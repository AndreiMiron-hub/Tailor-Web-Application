using TailorWebApp.Application.Services.Authentification;
using TailorWebApp.Application.Services.Authentification.Interfaces;
using TailorWebApp.Application.Services.AzureStorageService;
using TailorWebApp.Application.Services.AzureStorageService.Interfaces;
using TailorWebApp.Application.Services.Locations;
using TailorWebApp.Application.Services.Locations.Interfaces;
using TailorWebApp.Application.Services.NewsArticles;
using TailorWebApp.Application.Services.NewsArticles.Interfaces;
using TailorWebApp.Application.Services.Orders;
using TailorWebApp.Application.Services.Orders.Interfaces;
using TailorWebApp.Application.Services.Products;
using TailorWebApp.Application.Services.Products.Interfaces;
using TailorWebApp.Application.Services.Staff;
using TailorWebApp.Application.Services.Staff.Interfaces;

namespace TailorWebApp.BE.ServiceExtensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<IProductStatusService, ProductStatusService>();
            services.AddScoped<IProductTagService, ProductTagService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IRegionService, RegionService>();

            services.AddScoped<IAuthenticationService, JwtService>();
            services.AddScoped<IUserTokenService, UserTokenService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IStaffScheduleService, StaffScheduleService>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IMeasurementsService, MeasurementsService>();
            services.AddScoped<IOfferedServiceService, OfferedServiceService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            services.AddScoped<INewsStatusService, NewsStatusService>();

            services.AddScoped<IAzureStorageService, AzureStorageService>();

            services.AddScoped<INewsService, NewsService>();

            return services;
        }
    }
}