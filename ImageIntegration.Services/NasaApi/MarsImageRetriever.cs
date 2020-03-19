using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Core.Entities;
using ImageIntegration.Core.ValueObjects;
using ImageIntegration.Services.NasaApi.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi
{
    public class MarsImageRetriever : IApiImageRetriever
    {
        private INasaApiImageRetriever _nasaImageRetriever;
        public MarsImageRetriever(INasaApiImageRetriever nasaImageRetriever)
        {
            _nasaImageRetriever = nasaImageRetriever;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(BaseGetRequest request)
        {
            var apiResponse = await _nasaImageRetriever.GetImagesAsync(request);
            return await ConvertToImages(apiResponse);
        }

        private async Task<IEnumerable<Image>> ConvertToImages(GetByEarthDateResponse resposne)
        {
            var convertToImageTasks = resposne.photos.Select(photo => FetchImage(photo));
            return await Task.WhenAll(convertToImageTasks);
        }

        private async Task<Image> FetchImage(Photo photo)
        {
            using (WebClient webClient = new WebClient())
            {
                var imageData = await webClient.DownloadDataTaskAsync(new Uri(photo.img_src));
                return new Image
                {
                    Data = imageData,
                    Name = photo.id.ToString(),
                    Extention = ImageFileExtension.From(photo.img_src.Split('.').Last())
                };
            }
        }
    }
}
