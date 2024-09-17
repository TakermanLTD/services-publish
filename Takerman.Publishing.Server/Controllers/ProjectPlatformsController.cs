using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectPlatformsController(IProjectPlatformsService projectsService) : ControllerBase
    {
        private readonly IProjectPlatformsService _projectsService = projectsService;

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProjectPlatform model)
        {
            return Ok(await _projectsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _projectsService.Delete(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int projectId, int postTypeId)
        {
            var platforms = await _projectsService.GetAll(projectId, postTypeId);

            return Ok(platforms);
        }

        [HttpPut("UpdateAll")]
        public async Task<IActionResult> UpdateAll(IEnumerable<ProjectPlatform> model)
        {
            return Ok(await _projectsService.Update(model));
        }
    }
}