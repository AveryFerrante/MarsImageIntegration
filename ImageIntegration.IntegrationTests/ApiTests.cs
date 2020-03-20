using ImageIntegration.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ImageIntegration.IntegrationTests
{
    public class ApiTests
    {
        private HttpClient _client;

        public ApiTests()
        {
            var apiFactory = new WebApplicationFactory<Startup>();
            _client = apiFactory.CreateClient();
        }

        [Fact]
        public async void GetImagesAsync_WithValidRequest_ReturnsOKResponse()
        {
            var response = await _client.GetAsync("mars-images?date=10-10-2010");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetImagesAsync_WithInvalidRequest_ReturnsBadRequestResponse()
        {
            var response = await _client.GetAsync("mars-images?noDate=noDate");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
