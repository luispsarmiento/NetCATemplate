using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCATemplate.Application.Abstractions.Data;
using NetCATemplate.Infrastructure.Database;
using NetCATemplate.Infrastructure.Time;
using NetCATemplate.SharedKernel;

namespace NetCATemplate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration) =>
           services
               .AddServices();
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
