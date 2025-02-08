using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;
using Takerman.Publish.Services.Publishing.Abstraction;

namespace Takerman.Publish.Server.Controllers
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

        [HttpGet("GetByProjectId")]
        public async Task<List<PostDto>> GetByProject(int projectId)
        {
            return await _postService.GetByProject(projectId);
        }

        [HttpGet("GetByProjectName")]
        public async Task<List<PostDto>> GetByProject(string projectName)
        {
            return await _postService.GetByProject(projectName);
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