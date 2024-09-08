using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.DTOs;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(ILogger<PublishController> logger, IPublishService _publishService) : ControllerBase
    {
        private readonly ILogger<PublishController> _logger = logger;

        [HttpPost("PublishBlogpost")]
        public async Task<IActionResult> PublishBlogpost(int projectId, PublishBlogpostDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishPicture")]
        public async Task<IActionResult> PublishPicture(int projectId, PublishPictureDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishSelling")]
        public async Task<IActionResult> PublishSelling(int projectId, PublishSellingDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishShort")]
        public async Task<IActionResult> PublishShort(int projectId, PublishShortDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishTweet")]
        public async Task<IActionResult> PublishTweet(int projectId, PublishTweetDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishVideo")]
        public async Task<IActionResult> PublishVideo(int projectId, PublishVideoDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }
    }
}