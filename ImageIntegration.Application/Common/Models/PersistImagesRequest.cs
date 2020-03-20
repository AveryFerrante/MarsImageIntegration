using ImageIntegration.Core.Entities;
using System.Collections.Generic;

namespace ImageIntegration.Application.Common.Models
{
    public class PersistImagesRequest
    {
        public string Directory { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
