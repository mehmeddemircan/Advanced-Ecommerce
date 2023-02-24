using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        IModelService _modelService; 

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("Get-All-Model")]

        public async  Task<IActionResult> GetAllModel()
        {
            var result = await _modelService.GetListAsync();
            if (result != null)
            {
                return Ok(result); 
            }

            return BadRequest();
        }


        [HttpPost("Add-Model")]

        public async Task<IActionResult> AddModel([FromBody] ModelAddDto modelAddDto)
        {
            var result = await _modelService.AddAsync(modelAddDto);
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }


        [HttpGet("Get-Model/{id}")]

        public async Task<IActionResult> GetSingleModel(int id)
        {
            var result = await _modelService.GetAsync(x => x.Id == id );
            if (result != null)
            {
                return Ok(result); 
            }
            return BadRequest(); 
        }

        [HttpDelete("Delete-Model/{id}")]

        public async Task<IActionResult> DeleteModel (int id)
        {
            var result = await _modelService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(); 
        }
    }
}
