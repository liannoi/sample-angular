using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleAngular.Application;
using SampleAngular.Infrastructure;
using SampleAngular.Infrastructure.Persistence;

namespace SampleAngular.WebAPI
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
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHealthChecks().AddDbContextCheck<SampleAngularContext>();

            services.AddCors();
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod());
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                "default",
                "{controller=Products}/{action=GetAll}/{id?}"));
        }
    }
}