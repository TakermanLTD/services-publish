using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(ILogger<PublishController> logger, IPublishService _publishService) : ControllerBase
    {
        private readonly ILogger<PublishController> _logger = logger;

        [HttpPost("PublishBlogpost")]
        public async Task<IActionResult> PublishBlogpost(int projectId, PublicationBlogpostDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishPicture")]
        public async Task<IActionResult> PublishPicture(int projectId, PublicationPictureDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishSelling")]
        public async Task<IActionResult> PublishSelling(int projectId, PublicationSellingDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishShort")]
        public async Task<IActionResult> PublishShort(int projectId, PublicationShortDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishTweet")]
        public async Task<IActionResult> PublishTweet(int projectId, PublicationTweetDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishVideo")]
        public async Task<IActionResult> PublishVideo(int projectId, PublicationVideoDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }
    }
}