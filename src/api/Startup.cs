using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SampleAngular.Application;
using SampleAngular.Infrastructure;
using SampleAngular.Infrastructure.Persistence;
using SampleAngular.WebAPI.Infrastructure;

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
            services.AddTransient<IWebImageSaver, WebImageSaver>();

            services.AddHealthChecks().AddDbContextCheck<SampleAngularContext>();

            services.AddCors();
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sample Angular API",
                    Description =
                        "Sample SPA application on Angular to demonstrate the basic idea of developing the most modern and most relevant type of web applications for today.",
                    License = new OpenApiLicense
                    {
                        Name = "Web API licensed under Apache-2.0",
                        Url = new Uri("https://github.com/liannoi/sample-angular/blob/master/LICENSE")
                    }
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Angular API v1"));

            app.UseCors(options => options
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(ApiDefaults.PhotosDirectoryRoot),
                RequestPath = new PathString(ApiDefaults.PhotosDirectoryRootRequestPath)
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                "default",
                "{controller=Products}/{action=GetAll}/{id?}"));
        }
    }
}