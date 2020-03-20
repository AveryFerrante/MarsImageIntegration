using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi;
using ImageIntegration.Services.NasaApi.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace ImageIntegration.IntegrationTests
{
    public class ImageRetrieverTests
    {
        [Fact]
        public async void GetImages_WithValidRequest_ReturnsResults()
        {
            var expected = 5;
            var imageRetriever = GetMockImageRetrieverThatReturnsXResults(5);
            var request = new GetByEarthDateRequest { Date = new DateTime() };

            var response = await imageRetriever.GetImagesAsync(request);

            Assert.Equal(expected, response.Count());
        }

        private IImageRetriever<GetByEarthDateRequest> GetMockImageRetrieverThatReturnsXResults(int x)
        {
            Mock<INasaApiImageRetriever> mockApiRetriever = GetMockApiImageRetrieverThatReturnsXResults(x);

            var mockImageDownloader = new Mock<IImageDownloader>();
            mockImageDownloader.Setup(d => d.FetchImage(It.IsAny<Uri>()))
                .Returns(Task.FromResult(new byte[0]));

            return new MarsImageRetriever(mockApiRetriever.Object, mockImageDownloader.Object);
        }

        private static Mock<INasaApiImageRetriever> GetMockApiImageRetrieverThatReturnsXResults(int x)
        {
            var mockPhotoData = new List<Photo>();
            Enumerable.Range(0, x).ToList().ForEach((i) => mockPhotoData.Add(new Photo { img_src = "http://wwww.placeholder.com/placeholder.jpg", id = i }));
            var mockApiRetriever = new Mock<INasaApiImageRetriever>();

            mockApiRetriever.Setup(o => o.GetImagesAsync(It.IsAny<GetByEarthDateRequest>()))
                .Returns(Task.FromResult(new GetByEarthDateResponse { photos = mockPhotoData }));

            return mockApiRetriever;
        }
    }
}
