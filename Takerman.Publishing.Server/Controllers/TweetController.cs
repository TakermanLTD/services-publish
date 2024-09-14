using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetController(ITweetService _tweetService) : ControllerBase
    {
        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationTweetDto model)
        {
            return Ok(await _tweetService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _tweetService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _tweetService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _tweetService.GetAll(project));
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationTweetDto model)
        {
            return Ok(await _tweetService.Publish(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationTweet model)
        {
            return Ok(await _tweetService.Update(model));
        }
    }
}