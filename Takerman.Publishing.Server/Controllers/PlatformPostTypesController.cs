using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformPostTypesController(IPlatformPostTypesService _platformPostTypesService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlatformPostType model)
        {
            return Ok(await _platformPostTypesService.Create(model.PlatformId, model.PostTypeId));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _platformPostTypesService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _platformPostTypesService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int platformId)
        {
            return Ok(await _platformPostTypesService.GetAll(platformId));
        }

        [HttpGet("GetAvailable")]
        public async Task<IActionResult> GetAvailable(int projectId, int postTypeId)
        {
            return Ok(await _platformPostTypesService.GetAvailable(projectId, postTypeId));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlatformPostTypesDto model)
        {
            return Ok(await _platformPostTypesService.Update(model));
        }
    }
}