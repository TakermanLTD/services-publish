using Microsoft.AspNetCore.Mvc;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetEnum")]
        public IActionResult GetEnum(string enumName)
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
    }
}