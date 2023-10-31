using Microsoft.EntityFrameworkCore;
using TailorWebApp.Infrastructure.Data;

namespace TailorWebApp.BE.ServiceExtensions
{
    public static class RegisterDatabases
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationConnectionString = configuration.GetConnectionString("TailorAppDBConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(applicationConnectionString));

            return services;
        }
    }
}