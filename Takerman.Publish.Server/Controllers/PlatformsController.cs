using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformsController(IPlatformsService _platformService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Platform model)
        {
            return Ok(await _platformService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _platformService.Delete(id));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _platformService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _platformService.GetAll());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Platform model)
        {
            return Ok(await _platformService.Update(model));
        }
    }
}