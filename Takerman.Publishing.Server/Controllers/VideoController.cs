using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController(IVideoService _videoService) : ControllerBase
    {
        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationVideoDto model)
        {
            return Ok(await _videoService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _videoService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _videoService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _videoService.GetAll(project));
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationVideoDto model)
        {
            return Ok(await _videoService.Publish(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationVideo model)
        {
            return Ok(await _videoService.Update(model));
        }
    }
}