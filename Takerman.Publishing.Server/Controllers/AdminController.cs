using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.DTOs;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController(ILogger<AdminController> logger, IProjectsService projectsService) : ControllerBase
    {
        private readonly ILogger<AdminController> _logger = logger;
        private readonly IProjectsService _projectsService = projectsService;

        [HttpPost("AddPlatformToProject")]
        public async Task<IActionResult> AddPlatformToProject(PlatformToProjectDto model)
        {
            return Ok(await _projectsService.AddPlatformToProject(model));
        }

        [HttpDelete("DeleteProjectToPlatform")]
        public async Task<IActionResult> DeleteProjectToPlatform(int id)
        {
            return Ok(await _projectsService.DeleteProjectToPlatform(id));
        }
    }
}