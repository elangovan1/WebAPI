using Microsoft.Extensions.DependencyInjection;
using MMT.DataEFCore.DBContext;
using MMT.DataEFCore.Handler;
using MMT.DataEFCore.Repositories;
using MMT.Domain.Interface;
using MMT.Domain.Interfaces;

namespace MMT.WebApi
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DatabaseContext>()
                    .AddScoped<ICustomerRepositoryModel, CustomerRepositoryModel>()
                    .AddScoped<ICustomerEntityHandler, CustomerEntityHandler>();


            return services;
        }
    }
}
