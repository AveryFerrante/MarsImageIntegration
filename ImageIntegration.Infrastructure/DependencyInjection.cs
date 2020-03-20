using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Infrastructure.LocalDiskPersistance;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace ImageIntegration.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDiskPersistor, LocalDiskPersistor>();
            return services;
        }
    }
}
