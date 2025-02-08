using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformSecretsController(IPlatformSecretsService _platformSecretsService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlatformSecret model)
        {
            return Ok(await _platformSecretsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _platformSecretsService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _platformSecretsService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int platformId)
        {
            return Ok(await _platformSecretsService.GetAll(platformId));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlatformSecret model)
        {
            return Ok(await _platformSecretsService.Update(model));
        }
    }
}