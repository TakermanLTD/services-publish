using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController(IProjectsService _projectsService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Project model)
        {
            return Ok(await _projectsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _projectsService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _projectsService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<List<Project>> GetAll()
        {
            return await _projectsService.GetAll();
        }

        [HttpPut("Update")]
        public async Task<Project> Update(Project model)
        {
            return await _projectsService.Update(model);
        }
    }
}