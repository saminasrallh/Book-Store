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
    public class BookController : ControllerBase
    {
       private readonly IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet("getallbook")]
        public async Task<IActionResult> GetallBook()
        {
           var getbook= await _bookServices.GetallBook();
            return Ok(getbook);
        }
        [HttpGet("getBookbyid")]
        public async Task<IActionResult> GetBookByID(int id)
        {
           var getbook= await _bookServices.GetBookByID(id);

            return Ok(getbook);

        }
        [HttpGet("GetBookByName")]
        public async Task<IActionResult> GetBookByName(string Title)
        {
            var getbook=await _bookServices.GetBookByName(Title);
           return Ok(getbook);
        }

        [HttpPost("CreateeBook")]
        public async Task<IActionResult> CreateeBook(BookModelCreate book)
        {
           
           await _bookServices.CreateBook(book);
            return Ok(book);

        }
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
           
          var delete= await _bookServices.DeleteBook(id);
            return Ok(delete);
           
        }
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookModel book)

        {
           
         var update= await _bookServices.UpdateBook(id,book);
            
            return Ok(update);
        }
        




    }
}
