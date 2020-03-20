using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi.Interfaces
{
    public interface INasaApiImageRetriever
    {
        Task<GetByEarthDateResponse> GetImagesAsync(GetByEarthDateRequest request);
    }
}
