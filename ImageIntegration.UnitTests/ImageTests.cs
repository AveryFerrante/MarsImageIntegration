using System;
using Xunit;
using ImageIntegration.Core;
using ImageIntegration.Core.ValueObjects;
using ImageIntegration.Core.Exceptions;

namespace ImageIntegration.UnitTests
{
    public class ImageTests
    {
        [Theory]
        [InlineData("jpg")]
        [InlineData("jpeg")]
        [InlineData("png")]
        public void ImageFileExtension_GivenValidImageExtension_ShouldNotThrowException(string imageExtension)
        {
            var exception = Record.Exception(() => ImageFileExtension.From(imageExtension));
            Assert.Null(exception);
        }

        [Fact]
        public void ImageFileExtension_GivenInvalidImageExtension_ShouldThrowException()
        {
            Assert.Throws<ImageFileExtensionInvalidException>(() => ImageFileExtension.From("invalidExtension"));
        }
    }
}
