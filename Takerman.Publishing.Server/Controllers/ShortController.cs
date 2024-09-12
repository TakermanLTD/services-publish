using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortController(IShortService _shortService) : ControllerBase
    {
        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationShortDto model)
        {
            return Ok(await _shortService.Publish(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _shortService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _shortService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _shortService.GetAll(project));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationShortDto model)
        {
            return Ok(await _shortService.Create(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationShort model)
        {
            return Ok(await _shortService.Update(model));
        }
    }
}