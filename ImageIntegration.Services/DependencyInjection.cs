using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi;
using ImageIntegration.Services.NasaApi.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ImageIntegration.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IImageRetriever<GetByEarthDateRequest>, MarsImageRetriever>()
                .AddNasaService();
            return services;
        }

        public static IServiceCollection AddNasaService(this IServiceCollection services)
        {
            services.AddSingleton<INasaApiImageRetriever, NasaApiImageRetriever>();
            return services;
        }
    }
}
