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
    public class MarsImageRetriever : IImageRetriever<GetByEarthDateRequest>
    {
        private INasaApiImageRetriever _nasaImageRetriever;
        private IImageDownloader _imageDownloader;
        public MarsImageRetriever(INasaApiImageRetriever nasaImageRetriever, IImageDownloader imageDownloader)
        {
            _nasaImageRetriever = nasaImageRetriever;
            _imageDownloader = imageDownloader;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(GetByEarthDateRequest request)
        {
            var apiResponse = await _nasaImageRetriever.GetImagesAsync(request);
            return await ConvertToImages(apiResponse);
        }

        private async Task<IEnumerable<Image>> ConvertToImages(GetByEarthDateResponse resposne)
        {
            var convertToImageTasks = resposne.photos.Select(async photo => new Image
            { 
                Data = await _imageDownloader.FetchImage(new Uri(photo.img_src)),
                Name = photo.id.ToString(),
                Extention = ImageFileExtension.From(photo.img_src.Split('.').Last())
            });
            return await Task.WhenAll(convertToImageTasks);
        }
    }
}
