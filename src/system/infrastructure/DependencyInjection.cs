using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Common.Pagings;
using SampleAngular.Infrastructure.Common.Pagings;
using SampleAngular.Infrastructure.Persistence;

namespace SampleAngular.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SampleAngularContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISampleAngularContext>(provider => provider.GetService<SampleAngularContext>());

            services.AddTransient<IPagingDetails, PagingDetails>();

            return services;
        }
    }
}