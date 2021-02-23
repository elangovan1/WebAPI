using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMT.DataEFCore.DBContext;

namespace MMT.WebApi
{
    public static class ConnectionString
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,  IConfiguration configuration)
        {            
            services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(configuration["ConnectionString:MMTDB"]));
            return services;
        }
    }
}
