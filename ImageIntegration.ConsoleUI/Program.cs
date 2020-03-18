using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using ImageIntegration.Infrastructure;
using ImageIntegration.Services.NasaApi;
using ImageIntegration.Services;
using ImageIntegration.Services.NasaApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageIntegration.ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();
            var request = new GetByEarthDateRequest
            {
                Date = new DateTime(2015, 6, 3)
            };
            var images = await GetImages(request);
            await SaveImages(images, serviceProvider);

        }

        private async static Task<IEnumerable<Image>> GetImages(GetByEarthDateRequest request)
        {
            var imageRetriever = new MarsImageRetriever();
            return await imageRetriever.GetImagesAsync(request);
        }

        private async static Task SaveImages(IEnumerable<Image> images, ServiceProvider services)
        {
            var imageSaver = services.GetService<IDiskPersistor>();
            var saveDirectory = GetDirectory();
            await imageSaver.PersistImagesAsync(new PersistImagesRequest { Images = images, Directory = saveDirectory });
        }

        private static string GetDirectory()
        {
            var saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MarsImages");
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            return saveDirectory;
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddInfrastructure()
                .AddServices();
            return serviceProvider.BuildServiceProvider();
        }
    }
}
