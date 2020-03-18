using ImageIntegration.Application.Common.Models;
using ImageIntegration.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageIntegration.Application.Common.Interfaces
{
    public interface IDiskPersistor
    {
        Task PersistImagesAsync(PersistImagesRequest request);
    }
}
