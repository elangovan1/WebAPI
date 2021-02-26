using Ensek.Web.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMS.API.Configurations;
using System.Text;

namespace Ensek.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddConnectionProvider(Configuration);
            services.ConfigureRepositories();
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext =>
                    new BadRequestObjectResult(actionContext.ModelState);
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Ensek API",
                    Version = "v2",
                    Description = "Meter Management",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            string[] origins = new string[] { "http://localhost:4200" };
            app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins));

            app.UseHttpsRedirection();            
            app.UseStaticFiles();            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {               
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=GetAll}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Meter Management"));
        }
    }
}
