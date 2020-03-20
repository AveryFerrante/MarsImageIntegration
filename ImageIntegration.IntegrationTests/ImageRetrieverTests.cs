using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi;
using ImageIntegration.Services.NasaApi.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace ImageIntegration.IntegrationTests
{
    public class ImageRetrieverTests
    {
        [Fact]
        public async void GetImages_WithValidRequest_ReturnsResults()
        {
            var imageRetriever = GetImageRetriever();
            var request = new GetByEarthDateRequest { Date = new DateTime(2015, 6, 3) };

            var response = await imageRetriever.GetImagesAsync(request);

            Assert.NotEmpty(response);
        }

        [Fact]
        public async void GetImages_WithInvalidRequest_ReturnsNoResults()
        {
            var imageRetriever = GetImageRetriever();
            var request = new GetByEarthDateRequest { Date = DateTime.MaxValue };

            var response = await imageRetriever.GetImagesAsync(request);

            Assert.Empty(response);
        }

        private IImageRetriever<GetByEarthDateRequest> GetImageRetriever()
        {
            var mockedApiRetriever = new Mock<INasaApiImageRetriever>();
            var a = new Mock<WebClient>();
            a.Setup(wc => wc.DownloadDataTaskAsync(It.IsAny<string>()));
            mockedApiRetriever.Setup(o => o.GetImagesAsync(It.IsAny<GetByEarthDateRequest>()));
            return new MarsImageRetriever(mockedApiRetriever.Object);
        }
    }
}
