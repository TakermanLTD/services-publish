using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;
using Takerman.Marketplace.Services.Services;

namespace Takerman.Marketplace.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(ILogger<PublishController> logger, IPublishService _publishService, IOptions<PlatformsConfig> _platformConfigs) : ControllerBase
    {
        private readonly ILogger<PublishController> _logger = logger;

        [HttpPost("PublishPost")]
        public async Task<IActionResult> PublishPost(PostDto model)
        {
            return Ok(await _publishService.PublishAsync(model, _platformConfigs));
        }
    }
}