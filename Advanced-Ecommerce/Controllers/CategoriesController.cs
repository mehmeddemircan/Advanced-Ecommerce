using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService; 
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Get-All-Category")]
        
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetListAsync();
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest();
        }

        [HttpPost("Add-Category")]

        public async Task<IActionResult> AddCategory([FromBody] CategoryAddDto categoryAddDto)
        {
            var result = await _categoryService.AddAsync(categoryAddDto);

            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }

        [HttpGet("Get-Category/{id}")]

        public async Task<IActionResult> GetSingleCategory(int id )
        {
            var result = await _categoryService.GetAsync(x => x.Id == id);

            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }

        [HttpDelete("Delete-Category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message); 
            }
            return BadRequest(); 
        }

        [HttpPut("Update-Category")]

        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.UpdateAsync(categoryUpdateDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(); 
        }

    }
}
