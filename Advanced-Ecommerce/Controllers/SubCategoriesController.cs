using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        ISubCategoryService _subCategoryService; 

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("Get-All-SubCategory")]

        public  async Task<IActionResult> GetAllSubCategory()
        {
            var result = await _subCategoryService.GetListAsync();
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }


        [HttpGet("Get-Subcategory/{id}")]

        public async Task<IActionResult> GetSingleSubCategory(int id)
        {
            var result = await _subCategoryService.GetAsync(x => x.Id == id);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(); 
        }


        [HttpPost("Add-SubCategory")]

        public async Task<IActionResult> AddSubCategory([FromBody] SubCategoryAddDto subCategoryAddDto)
        {
            var result = await _subCategoryService.AddAsync(subCategoryAddDto);
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }

        [HttpDelete("Delete-SubCategory/{id}")]

        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var result = await _subCategoryService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(); 
        }

    }
}
