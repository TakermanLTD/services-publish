using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectPlatformRecordsController(IProjectPlatformRecordService recordsService) : ControllerBase
    {
        private readonly IProjectPlatformRecordService _recordsService = recordsService;

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProjectPlatformRecord model)
        {
            return Ok(await _recordsService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _recordsService.Delete(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int projectPlatformId)
        {
            var platforms = await _recordsService.GetAll(projectPlatformId);

            return Ok(platforms);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProjectPlatformRecord model)
        {
            return Ok(await _recordsService.Update(model));
        }
    }
}