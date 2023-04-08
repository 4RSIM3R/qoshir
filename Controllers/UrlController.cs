using Microsoft.AspNetCore.Mvc;
using Qoshir.DTO;
using Qoshir.Grain;
using System.Web;
using System.Xml;

namespace Qoshir.Controllers
{
    [ApiController]
    [Route("url")]
    public class UrlController : Controller
    {

        [HttpGet("short/{path}")]
        public async Task<IActionResult> ShortenUrl(IGrainFactory grain, string path)
        {
            var uniqueId = Guid.NewGuid().GetHashCode().ToString("X");
            var shortenerGrain = grain.GetGrain<IUrlShortenerGrain>(uniqueId);
            await shortenerGrain.SetUrl(uniqueId, HttpUtility.UrlDecode(path));

            var response = new UrlDTO
            {
                Url = $"short/{uniqueId}"
            };

            return Ok(response);
        }

        [HttpGet("go/{id}")]
        public async Task<IActionResult> RedirectUrl(IGrainFactory grains, string id)
        {

            var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(id);
            var url = await shortenerGrain.GetUrl();

            var response = new UrlDTO
            {
                Url = url
            };

            return Ok(response);
        }

    }
}
