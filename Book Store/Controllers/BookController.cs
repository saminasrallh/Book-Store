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
    public class BookController : ControllerBase
    {
        private readonly IBookRepostory _bookRepostory;

        public BookController(IBookRepostory bookRepostory)
        {
            _bookRepostory = bookRepostory;
        }
        [HttpGet("getallbook")]
        public async Task<IActionResult> GetallBook()
        {
           var getbook= await _bookRepostory.GetallBook();
            return Ok(getbook);
        }
        [HttpGet("getBookbyid")]
        public async Task<IActionResult> GetBookByID(int id)
        {
           var getbook= await _bookRepostory.GetBookByID(id);
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
        [HttpGet("GetBookByName")]
        public async Task<IActionResult> GetBookByName(string Title)
        {
            var getbook=await _bookRepostory.GetBookByName(Title);
            if (getbook != null)
            {
                return Ok(getbook);
            }
            else
            {
                return Ok("not found");
            }
        }

        [HttpPost("CreateeBook")]
        public async Task<IActionResult> CreateeBook(BookModelCreate book)
        {
            var create = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Quantity = book.Quantity,
                Price = book.Price,
                CreatedBy = book.CreatedBy,
                AutherId = book.AutherId,
                AvulebelQuantity=book.Quantity,
                
                
            };
           await _bookRepostory.CreateBook(create);
            return Ok(create);

        }
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var delete =await _bookRepostory.GetBookByID(id);
            _bookRepostory.DeleteBook(delete);
            return Ok(delete);
           
        }
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookModel book)

        {
            var updatebook = await _bookRepostory.GetBookByID(id);

            updatebook.Title=book.Title;
           updatebook.Description=book.Description;
            updatebook.Quantity=book.Quantity;
            updatebook.Price=book.Price;
            updatebook.UpdateBy=book.UpdateBy;
            updatebook.LastUpdated= DateTime.Now;
           updatebook.AvulebelQuantity= book.Quantity;
           _bookRepostory.UpdateBook(updatebook);
            
            return Ok(updatebook);
        }
        




    }
}
