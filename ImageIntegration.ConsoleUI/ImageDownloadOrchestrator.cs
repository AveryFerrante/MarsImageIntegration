using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using ImageIntegration.Services.NasaApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageIntegration.ConsoleUI
{
    public class ImageDownloadOrchestrator
    {
        private IImageRetriever<GetByEarthDateRequest> _imageRetriever { get; set; }
        private IDiskPersistor _diskPersistor { get; set; }
        public ImageDownloadOrchestrator(IImageRetriever<GetByEarthDateRequest> imageRetriever, IDiskPersistor diskPersistor)
        {
            _imageRetriever = imageRetriever;
            _diskPersistor = diskPersistor;
        }

        public async Task DownloadImagesAsync(DateTime date, string directory)
        {
            var images = await _imageRetriever.GetImagesAsync(new GetByEarthDateRequest { Date = date });
            await PersistImagesAsync(images, directory);
        }

        private async Task PersistImagesAsync(IEnumerable<Image> images, string directory)
        {
            var saveDirectory = GetDirectory(directory);
            await _diskPersistor.PersistImagesAsync(new PersistImagesRequest { Images = images, Directory = saveDirectory });
        }

        private string GetDirectory(string directory)
        {
            var saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directory);
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            return saveDirectory;
        }
    }
}
