using System.Text.Json;
using System.Text.Json.Serialization;

namespace TailorWebApp.BE.ServiceExtensions
{
    public static class ConfigureControllers
    {
        public static IServiceCollection ConfigureControllersOptions(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            return services;
        }
    }
}