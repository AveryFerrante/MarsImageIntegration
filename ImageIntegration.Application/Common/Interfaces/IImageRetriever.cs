using ImageIntegration.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageIntegration.Application.Common.Interfaces
{
    public interface IImageRetriever<TRequest>
    {
        Task<IEnumerable<Image>> GetImagesAsync(TRequest request);
    }
}
