using Microsoft.AspNetCore.Mvc;
using Takerman.Marketplace.Services.Services;

namespace Takerman.Marketplace.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController(ILogger<HomeController> logger, IArtificialInteligenceService _artificialInteligenceService) : ControllerBase
    {
        private readonly ILogger<HomeController> _logger = logger;

        [HttpGet("GetEnum")]
        public IActionResult GetEnum(string enumName)
        {
            var dict = new Dictionary<int, string>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType("Takerman.Marketplace.Services.Enums." + enumName);

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
    }
}