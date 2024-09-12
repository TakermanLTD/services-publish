using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController(IBlogService _blogService) : ControllerBase
    {
        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationBlogpostDto model)
        {
            return Ok(await _blogService.Publish(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _blogService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _blogService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _blogService.GetAll(project));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationBlogpostDto model)
        {
            return Ok(await _blogService.Create(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationBlogpost model)
        {
            return Ok(await _blogService.Update(model));
        }
    }
}