using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(ILogger<PublishController> logger) : ControllerBase
    {
        private readonly ILogger<PublishController> _logger = logger;

        [HttpPost("PublishPost")]
        public async Task<IActionResult> PublishPost(Publication model)
        {
            return Ok();
        }
    }
}