using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformSecretsController(IPlatformSecetsService _secretsService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlatformSecret model)
        {
            return Ok(await _secretsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _secretsService.Delete(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int platformId)
        {
            var platforms = await _secretsService.GetAll(platformId);

            return Ok(platforms);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlatformSecret model)
        {
            return Ok(await _secretsService.Update(model));
        }
    }
}