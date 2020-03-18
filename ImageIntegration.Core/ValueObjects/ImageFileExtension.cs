using ImageIntegration.Core.Exceptions;

namespace ImageIntegration.Core.ValueObjects
{
    public class ImageFileExtension
    {
        private ImageFileExtension() { }

        public static ImageFileExtension From(string imageExtension)
        {
            var extension = new ImageFileExtension();
            // Other validations to ensure it is actually an image extension necessary, this is an example
            if (imageExtension.Length > 4)
            {
                throw new ImageFileExtensionInvalidException(imageExtension);
            }
            extension.Value = imageExtension;
            return extension;
        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
