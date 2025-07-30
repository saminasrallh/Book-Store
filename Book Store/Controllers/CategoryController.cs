using Book_Store.Entity;
using Book_Store.IRepostry;
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
        private readonly ICategoryRepostory _bookCategoryRepostory;

        public CategoryController(ICategoryRepostory bookCategoryRepostory)
        {
            _bookCategoryRepostory = bookCategoryRepostory;
        }
        [HttpGet("getallcategory")]
        public async Task<IActionResult> GetallCategory()
        {
            var getbook = await _bookCategoryRepostory.GetAllCategory();
            return Ok(getbook);
        }
        [HttpGet("GetAllCategoryAndBook")]
        public async Task<IActionResult> GetAllCategoryAndBook()
        {
            var getbook = await _bookCategoryRepostory.GetAllCategoryAndBook();
            return Ok(getbook);
        }


        [HttpGet("getCategorybyid")]
        public async Task<IActionResult> getCategorybyid(int id)
        {
            var getbook = await _bookCategoryRepostory.GetCategoryById(id);
            if (getbook != null)
            {
                return Ok(getbook);
            }
            else
            {
                return Ok("not found");
            }
           return Ok(getbook);

        }
        [HttpGet("GetCategoryByName")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var getbook = await _bookCategoryRepostory.GetCategoryByName(name);
            if (getbook != null)
            {
                return Ok(getbook);
            }
            else
            {
                return Ok("not found");
            }
        }
        [HttpGet("numberbookfromcategory")]
        public object numberbookfromcategory(int id)
        {
            return _bookCategoryRepostory.numberbookfromcategory(id);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(string category)
        {
            var create = new Category
            {
                Name=category


            };
            await _bookCategoryRepostory.CreateCategory(create);
            return Ok(create);

        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var delete = await _bookCategoryRepostory.GetCategoryById(id);
            _bookCategoryRepostory.DeleteCategory(delete);
            return Ok(delete);

        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id, string category)

        {
            var updatecatigory = await _bookCategoryRepostory.GetCategoryById(id);
             
            updatecatigory.Name = category;
            _bookCategoryRepostory.UpdateCategory(updatecatigory);

            return Ok(updatecatigory);
        }
       



    }
}
