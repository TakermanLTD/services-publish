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
            var dict = enumName.GetEnumMembers();

            return Ok(dict);
        }
    }
}