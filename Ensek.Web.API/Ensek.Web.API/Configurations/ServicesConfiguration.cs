using Ensek.Web.API.Database;
using Ensek.Web.API.DataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Ensek.Web.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DatabaseContext>()
                    .AddScoped<IMeterReadingUploadRepository, MeterReadingUploadRepository>()
                    .AddScoped<IMeterReadingRepository, MeterReadingRepository>();

            return services;
        }
    }
}
