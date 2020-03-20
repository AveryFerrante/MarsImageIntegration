using ImageIntegration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageIntegration.Services.NasaApi.Interfaces
{
    public interface IImageDownloader
    {
        Task<byte[]> FetchImage(Uri imageUri);
    }
}
