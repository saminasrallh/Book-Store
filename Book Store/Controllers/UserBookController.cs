using Book_Store.Entity;
using Book_Store.IRepostry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class UserBookController : ControllerBase
    {
        private readonly IUserBookRepostory _userBookRepostory ;
        private readonly IBookRepostory _bookRepostory ;

       

        public UserBookController(IUserBookRepostory userBookRepostory, IBookRepostory bookRepostory)
        {
            _userBookRepostory = userBookRepostory;
            _bookRepostory = bookRepostory;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> getall()
        {
          var get=  await _userBookRepostory.getallRenter();
            return Ok(get);
        }
        [HttpGet("getRenyedBooksbyUserId")]
        public async Task <IActionResult> getRenyedBooksbyUserId(int id)
        {
           var get= await _userBookRepostory.getRenyedBooksbyUserId(id);
            if (get == null) {
                return BadRequest("No Book Rental");
            }
            return Ok(get);
        }
        [HttpGet("getRenyedBooksbybookId")]
        public async Task <IActionResult> getRenyedBooksbybookId(int id)
        {

           var get= _userBookRepostory.getRenyedBooksbybookId(id);
            if (get == null) {
                return BadRequest("No Book Rental");
            }
            return Ok(get);
        }
        [HttpPost("RentelBook")]
        
        public async Task<IActionResult>create(int userid, int bookid)
        {
           var getbook= await _bookRepostory.GetBookByID(bookid);
           if((getbook.Quantity -getbook.AvailableBookCount)>1)
            {
                return Ok("The Book Not Avelubel");
            }
            var create = new UserBook
            {
                UserId = userid,
                BookId = bookid
            };

            _userBookRepostory.create(create);
            return Ok(create);
        }
        [HttpPut("ReturnBook")]
        public async Task <IActionResult>ReturnBook(int id)
        {
            var get = new UserBook();
               get=await _userBookRepostory.GetById(id);
            get.ReturnTime = DateTime.Now;
           await _userBookRepostory.RetarnBook(get);
            return Ok(get);
            
        }


    }
}
