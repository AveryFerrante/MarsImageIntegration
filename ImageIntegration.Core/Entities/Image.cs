using ImageIntegration.Core.ValueObjects;

namespace ImageIntegration.Core.Entities
{
    public class Image
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public ImageFileExtension Extention { get; set; }
    }
}
