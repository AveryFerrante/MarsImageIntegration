using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using ImageIntegration.Core.ValueObjects;
using ImageIntegration.Services.NasaApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi
{
    public class MarsImageRetriever : IApiImageRetriever
    {
        public async Task<IEnumerable<Image>> GetImagesAsync(BaseGetRequest request)
        {
            var apiResponse = await GetApiResponse(request);
            GetByEarthDateResponse response = JsonConvert.DeserializeObject<GetByEarthDateResponse>(apiResponse);
            return await ConvertToImages(response);
        }

        private async Task<string> GetApiResponse(BaseGetRequest request)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var queryParameters = request.GetQueryString();
                queryParameters += "&api_key=GZJxTcYqUUuZ4NTnFWhBXjd71AJASmWSQ2kpAskN";
                var response = await httpClient.GetAsync(@"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?" + queryParameters);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
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
                var imageData = await webClient.DownloadDataTaskAsync(new System.Uri(photo.img_src));
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
