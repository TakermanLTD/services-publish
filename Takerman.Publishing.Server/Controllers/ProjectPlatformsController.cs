using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectPlatformsController(IProjectPlatformsService _projectsService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProjectPlatform model)
        {
            return Ok(await _projectsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ProjectPlatformSecretDto model)
        {
            return Ok(await _projectsService.Delete(model));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int projectId, int postTypeId)
        {
            var platforms = await _projectsService.GetAll(projectId, postTypeId);

            return Ok(platforms);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProjectPlatformSecretDto model)
        {
            return Ok(await _projectsService.Update(model));
        }
    }
}