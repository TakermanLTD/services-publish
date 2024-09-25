using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectSecretsController(IProjectSecretsService _secretsService) : ControllerBase
    {
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int projectId, int platformId)
        {
            return Ok(await _secretsService.Delete(new Services.Dtos.ProjectSecretDto() { ProjectId = projectId, PlatformId = platformId }));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int projectId, int platformId)
        {
            var platforms = await _secretsService.Get(projectId, platformId);

            return Ok(platforms);
        }
    }
}