using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController(IProjectService _projectsService) : ControllerBase
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
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _projectsService.GetAll()).ToList());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Project model)
        {
            return Ok(await _projectsService.Update(model));
        }
    }
}