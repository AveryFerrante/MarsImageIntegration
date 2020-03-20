using ImageIntegration.Core.Entities;
using ImageIntegration.Services.NasaApi.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi
{
    public class ImageDownloader : IImageDownloader
    {
        public async Task<byte[]> FetchImage(Uri imageUri)
        {
            using (var webClient = new WebClient())
            {
                return await webClient.DownloadDataTaskAsync(imageUri);
            }
        }
    }
}
