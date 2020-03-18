using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi;
using Microsoft.Extensions.DependencyInjection;

namespace ImageIntegration.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IApiImageRetriever, MarsImageRetriever>();
            return services;
        }
    }
}
