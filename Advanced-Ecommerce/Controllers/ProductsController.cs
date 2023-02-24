using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _producService;
        IProductColorService _productColorService; 
        public ProductsController(IProductService producService, IProductColorService productColorService)
        {
            _producService = producService;
            _productColorService = productColorService;
        }


        [HttpGet("Get-All-Product")]

        public async Task<IActionResult> GetProductList()
        {
            var result = await _producService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("Add-Product")]

        public async Task<IActionResult> AddBrand([FromBody] ProductAddDto productAddDto)
        {
            var result = await _producService.AddAsync(productAddDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("Get-By-Id/{id}")]

        public async Task<IActionResult> GetSingleProduct(int id)
        {
            var result = await _producService.GetAsync(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete-Product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _producService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            return BadRequest(); 
        }

        [HttpPost("Add-Color-To-Product")]

        public async Task<IActionResult> AddColorToProduct(ProductColorAddDto productColorAddDto)
        {
            var result = await _productColorService.AddColorToProduct(productColorAddDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Remove-Color-To-Product")]

        public async Task<IActionResult> RemoveColorToProduct(int id)
        {
            var result = await _productColorService.DeleteProductColorAsync(id);

            if (result.Success)
            {
                return Ok(result.Message); 
            }
            return BadRequest(); 
        }
    }
}
