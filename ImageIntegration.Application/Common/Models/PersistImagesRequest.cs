using ImageIntegration.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageIntegration.Application.Common.Models
{
    public class PersistImagesRequest
    {
        public string Directory { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
