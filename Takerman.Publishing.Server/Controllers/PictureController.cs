using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController(IPictureService _pictureService) : ControllerBase
    {
        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationPictureDto model)
        {
            return Ok(await _pictureService.Create(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _pictureService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _pictureService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _pictureService.GetAll(project));
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationPictureDto model)
        {
            return Ok(await _pictureService.Publish(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationPicture model)
        {
            return Ok(await _pictureService.Update(model));
        }
    }
}