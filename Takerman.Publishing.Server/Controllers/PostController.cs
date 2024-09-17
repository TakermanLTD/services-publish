using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostController(IPostService _postService) : ControllerBase
    {
        [HttpGet("Create")]
        public async Task<IActionResult> Create(Post model)
        {
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int projectId)
        {
            return Ok(await _postService.GetAll(projectId));
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(Post model)
        {
            return Ok(await _postService.Publish(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(Post model)
        {
            return Ok(await _postService.Update(model));
        }
    }
}