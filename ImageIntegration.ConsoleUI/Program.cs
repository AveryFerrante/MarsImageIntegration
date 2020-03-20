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
        private static ServiceProvider _serviceProvider;
        static async Task Main(string[] args)
        {
            InitializeServiceProvider();
            var orchestrator = GetOrchestrator();
            Console.WriteLine("Please specify the directory (on the Desktop) to save images to: ");
            var directory = Console.ReadLine();

            Console.WriteLine("Begin Procecssing...");
            var dates = GetDatesFromFile("dates.txt");
            foreach (var date in dates)
            {
                await orchestrator.DownloadImagesAsync(date, directory);
            }
            Console.WriteLine("Finished Processing.");
        }

        private static IEnumerable<DateTime> GetDatesFromFile(string fileName)
        {
            var dates = new List<DateTime>();
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while (!sr.EndOfStream)
                    {
                        DateTime date = default;
                        var dateString = sr.ReadLine();
                        if (DateTime.TryParse(dateString, out date))
                        {
                            dates.Add(date);
                        }
                        else
                        {
                            Console.WriteLine($"Unable to process {dateString}. It will be skipped.");
                        }
                    }
                }
            }
            return dates;
        }

        private static void InitializeServiceProvider()
        {
            _serviceProvider = new ServiceCollection()
                .AddInfrastructure()
                .AddServices()
                .BuildServiceProvider();
        }

        private static ImageDownloadOrchestrator GetOrchestrator()
        {
            var retriever = _serviceProvider.GetService<IImageRetriever<GetByEarthDateRequest>>();
            var persistor = _serviceProvider.GetService<IDiskPersistor>();
            return new ImageDownloadOrchestrator(retriever, persistor);
        }
    }
}
