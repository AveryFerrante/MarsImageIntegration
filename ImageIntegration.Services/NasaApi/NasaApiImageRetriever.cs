using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi
{
    public class NasaApiImageRetriever : INasaApiImageRetriever
    {
        private const string API_KEY = "GZJxTcYqUUuZ4NTnFWhBXjd71AJASmWSQ2kpAskN";
        public async Task<GetByEarthDateResponse> GetImagesAsync(BaseGetRequest request)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var queryParameters = request.GetQueryString();
                queryParameters += $"&api_key={API_KEY}";
                var response = await httpClient.GetAsync(@"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?" + queryParameters);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetByEarthDateResponse>(responseData);
            }
        }
    }
}
