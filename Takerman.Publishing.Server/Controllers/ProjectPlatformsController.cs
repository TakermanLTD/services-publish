using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectPlatformsController(IProjectsService projectsService) : ControllerBase
    {
        private readonly IProjectsService _projectsService = projectsService;

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProjectPlatformDto model)
        {
            return Ok(await _projectsService.AddProjectPlatform(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _projectsService.DeleteProjectPlatform(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project, PostType postType)
        {
            var platforms = await _projectsService.GetPlatforms(project, postType);

            return Ok(platforms);
        }

        [HttpPut("UpdateAll")]
        public async Task<IActionResult> UpdateAll(IEnumerable<ProjectPlatform> model)
        {
            return Ok(await _projectsService.UpdateProjectPlatforms(model));
        }
    }
}