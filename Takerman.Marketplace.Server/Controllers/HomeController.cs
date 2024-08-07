using Microsoft.AspNetCore.Mvc;

namespace Takerman.Marketplace.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController(ILogger<HomeController> logger) : ControllerBase
    {
        private readonly ILogger<HomeController> _logger = logger;
    }
}
