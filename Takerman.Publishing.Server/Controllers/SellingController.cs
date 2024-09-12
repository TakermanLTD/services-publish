using Microsoft.AspNetCore.Mvc;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellingController(ISellingService _sellingService) : ControllerBase
    {
        [HttpPost("Publish")]
        public async Task<IActionResult> Publish(PublicationSellingDto model)
        {
            return Ok(await _sellingService.Publish(model));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _sellingService.Delete(id));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _sellingService.Get(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Project project)
        {
            return Ok(await _sellingService.GetAll(project));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create(PublicationSellingDto model)
        {
            return Ok(await _sellingService.Create(model));
        }

        [HttpGet("Update")]
        public async Task<IActionResult> Update(PublicationSelling model)
        {
            return Ok(await _sellingService.Update(model));
        }
    }
}