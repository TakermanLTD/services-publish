using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformLinksController(IPlatformLinksService _platformLinksService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlatformLink model)
        {
            return Ok(await _platformLinksService.Create(model));
        }

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
        public async Task<IActionResult> GetAll(int platformId)
        {
            return Ok(await _platformLinksService.GetAll(platformId));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlatformLink model)
        {
            return Ok(await _platformLinksService.Update(model));
        }
    }
}