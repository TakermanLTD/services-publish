using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController(ILogger<HomeController> logger, IProjectsService projectsService) : ControllerBase
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProjectsService _projectsService = projectsService;

        [HttpGet("GetEnum")]
        public async Task<IActionResult> GetEnum(string enumName)
        {
            var dict = new Dictionary<int, string>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType("Takerman.Publishing." + enumName);

                if (type == null)
                    continue;

                if (type.IsEnum)
                {
                    foreach (var name in Enum.GetNames(type))
                    {
                        dict.Add((int)Enum.Parse(type, name), name);
                    }
                }
            }

            return Ok(dict);
        }

        [HttpGet("GetPlatformsFiltered")]
        public async Task<IActionResult> GetPlatformsFiltered(Project project, PostType postType)
        {
            var platforms = await _projectsService.GetPlatforms(project, postType);

            return Ok(platforms);
        }
    }
}