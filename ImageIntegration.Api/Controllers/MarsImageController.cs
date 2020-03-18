using ImageIntegration.Application.Common.Interfaces;
using ImageIntegration.Services.NasaApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImageIntegration.Api.Controllers
{
    [ApiController]
    [Route("mars-images")]
    public class MarsImageController : ControllerBase
    {
        private IApiImageRetriever _retriever;

        public MarsImageController(IApiImageRetriever retriever)
        {
            _retriever = retriever;
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesAsync([FromQuery] GetByEarthDateRequest request)
        {
            var images = await _retriever.GetImagesAsync(request);
            return Ok(images);
        }
    }
}
