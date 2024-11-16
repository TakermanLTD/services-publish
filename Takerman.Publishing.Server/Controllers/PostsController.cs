using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IPostsService _postService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Post model)
        {
            model.PostType = null;
            model.Project = null;
            return Ok(await _postService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _postService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _postService.Get(id));
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(Post model)
        {
            model.PostType = null;
            model.Project = null;
            return Ok(await _postService.Publish(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(Post model)
        {
            model.PostType = null;
            model.Project = null;
            return Ok(await _postService.Update(model));
        }
    }
}