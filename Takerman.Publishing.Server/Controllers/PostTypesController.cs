using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostTypesController(IPostTypesService _postTypeService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PostType model)
        {
            return Ok(await _postTypeService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _postTypeService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _postTypeService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postTypeService.GetAll());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PostType model)
        {
            return Ok(await _postTypeService.Update(model));
        }
    }
}