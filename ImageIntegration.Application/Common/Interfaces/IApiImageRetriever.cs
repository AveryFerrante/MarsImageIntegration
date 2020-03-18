using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageIntegration.Application.Common.Interfaces
{
    public interface IApiImageRetriever
    {
        Task<IEnumerable<Image>> GetImagesAsync(BaseGetRequest request);
    }
}
