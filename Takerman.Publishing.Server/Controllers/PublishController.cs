using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(IPublishService _publishService) : ControllerBase
    {
        [HttpPost("PublishBlogpost")]
        public async Task<IActionResult> PublishBlogpost(PublicationBlogpostDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishPicture")]
        public async Task<IActionResult> PublishPicture(PublicationPictureDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishSelling")]
        public async Task<IActionResult> PublishSelling(PublicationSellingDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishShort")]
        public async Task<IActionResult> PublishShort(PublicationShortDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishTweet")]
        public async Task<IActionResult> PublishTweet(PublicationTweetDto model)
        {
            await _publishService.Publish(model);

            return Ok();
        }

        [HttpPost("PublishVideo")]
        public async Task<IActionResult> PublishVideo(PublicationVideoDto model)
        {
            await _publishService.Publish(model);
            return Ok();
        }
    }
}