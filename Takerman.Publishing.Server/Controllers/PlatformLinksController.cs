using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformLinksController(IPlatformLinksService _platformLinksService) : ControllerBase
    {
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _platformLinksService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _platformLinksService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Platform platform)
        {
            return Ok(await _platformLinksService.GetAll(platform));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlatformLinkDto model)
        {
            return Ok(await _platformLinksService.Create(model));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlatformLink model)
        {
            return Ok(await _platformLinksService.Update(model));
        }
    }
}