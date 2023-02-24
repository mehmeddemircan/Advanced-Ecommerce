using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Color;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService; 
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("Get-All-Color")]

        public async Task<IActionResult> GetAllColor ()
        {
            var result = await _colorService.GetListAsync();
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpPost("Add-Color")]

        public async Task<IActionResult> AddColor([FromBody] ColorAddDto colorAddDto)
        {
            var result = await _colorService.AddAsync(colorAddDto);
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }


    }
}
