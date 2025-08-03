using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
using Book_Store.Repostory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet("getallcategory")]
        public async Task<IActionResult> GetallCategory()
        {
            var getbook = await _services.GetAllCategory();
            return Ok(getbook);
        }
        [HttpGet("GetAllCategoryAndBook")]
        public async Task<IActionResult> GetAllCategoryAndBook()
        {
            var getbook = await _services.GetAllCategoryAndBook();
            return Ok(getbook);
        }


        [HttpGet("getCategorybyid")]
        public async Task<IActionResult> getCategorybyid(int id)
        {
            var getbook = await _services.GetCategoryById(id);
      
           return Ok(getbook);

        }
        [HttpGet("GetCategoryByName")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var getbook = await _services.GetCategoryByName(name);
            return Ok(getbook);
        }
        [HttpGet("numberbookfromcategory")]
        public object numberbookfromcategory(int id)
        {
            return _services.numberbookfromcategory(id);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(string category)
        {
           
           var create= await _services.CreateCategory(category);
            return Ok(create);

        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
          
          var delete= await _services.DeleteCategory(id);
            return Ok(delete);

        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id, string category)

        {
           var update= await _services.UpdateCategory(id, category);
            return Ok(update);
        }
       



    }
}
