using System;

namespace ImageIntegration.Core.Exceptions
{
    public class ImageFileExtensionInvalidException : Exception
    {
        public ImageFileExtensionInvalidException(string imageExtension)
            : base($"Image Extension \"{imageExtension}\" is invalid.")
        {
        }
    }
}
