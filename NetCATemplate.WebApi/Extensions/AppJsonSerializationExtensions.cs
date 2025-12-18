using NetCATemplate.WebApi.Infrastructure;

namespace NetCATemplate.WebApi.Extensions
{
    internal static class AppJsonSerializationExtensions
    {
        internal static IServiceCollection ConfigureAppJsonSerializer(this IServiceCollection services)
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });

            return services;
        }
    }
}
