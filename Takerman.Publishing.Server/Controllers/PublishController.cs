using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController(ILogger<PublishController> _logger, IPublishService _publishService, IProjectsService _projectsService) : ControllerBase
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

        [HttpPost("AddProjectPlatform")]
        public async Task<IActionResult> AddProjectPlatform(ProjectPlatformDto model)
        {
            return Ok(await _projectsService.AddProjectPlatform(model));
        }

        [HttpDelete("DeleteProjectPlatform")]
        public async Task<IActionResult> DeleteProjectPlatform(int id)
        {
            return Ok(await _projectsService.DeleteProjectPlatform(id));
        }
    }
}