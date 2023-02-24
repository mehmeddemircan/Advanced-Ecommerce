using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService; 
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("Get-All-Brand")]

        public async Task<IActionResult> GetBrandList()
        {
            var result = await _brandService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("Get-By-Id/{id}")]

        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await _brandService.GetAsync(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("Add-Brand")]

        public async Task<IActionResult> AddBrand([FromBody] BrandAddDto addBrandDto)
        {
            var result = await _brandService.AddAsync(addBrandDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("Edit-Brand")]

        public async Task<IActionResult> UpdateBrand([FromBody] BrandUpdateDto brandUpdateDto)
        {
            var result = await _brandService.UpdateAsync(brandUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete-Brand/{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            var result = await _brandService.DeleteAsync(id);

            if (result.Data)
            {
                return Ok(result.Message); 
            }
            return BadRequest(false); 
        }
    }
}
