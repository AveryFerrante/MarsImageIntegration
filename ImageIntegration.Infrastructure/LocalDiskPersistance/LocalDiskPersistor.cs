using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageIntegration.Infrastructure.LocalDiskPersistance
{
    public class LocalDiskPersistor : IDiskPersistor
    {
        public Task PersistImagesAsync(PersistImagesRequest request)
        {
            List<Task> saveTasks = new List<Task>();
            foreach (var image in request.Images)
            {
                saveTasks.Add(SaveImage(image, request.Directory));
            }
            return Task.WhenAll(saveTasks);
        }

        private async Task SaveImage(Image image, string directory)
        {
            using (FileStream fileStream = File.Create($"{directory}\\{image.Name}.{image.Extention}", image.Data.Length))
            {
                await fileStream.WriteAsync(image.Data, 0, image.Data.Length);
            }
        }
    }
}
