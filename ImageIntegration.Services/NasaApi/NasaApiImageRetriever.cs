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
        public async Task<GetByEarthDateResponse> GetImagesAsync(GetByEarthDateRequest request)
        {

            HttpResponseMessage response = await MakeRequest(request);
            response.EnsureSuccessStatusCode();
            return await DeserializeResponse(response);
        }

        private static async Task<GetByEarthDateResponse> DeserializeResponse(HttpResponseMessage response)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetByEarthDateResponse>(responseData);
        }

        private async Task<HttpResponseMessage> MakeRequest(GetByEarthDateRequest request)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var queryParameters = GetQueryString(request);
                return await httpClient.GetAsync(@"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?" + queryParameters);
            }
        }

        private string GetQueryString(GetByEarthDateRequest request)
        {
            var queryString = $"earth_date={request.Date.ToString("yyyy-MM-dd")}";
            if (!string.IsNullOrEmpty(request.Camera))
            {
                queryString += $"&camera={request.Camera}";
            }
            queryString += "&api_key=GZJxTcYqUUuZ4NTnFWhBXjd71AJASmWSQ2kpAskN";
            return queryString;
        }
    }
}
