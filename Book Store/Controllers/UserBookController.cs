using Book_Store.Entity;
using Book_Store.IRepostry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class UserBookController : ControllerBase
    {
        private readonly IUserBookRepostory _userBookRepostory ;
        private readonly IBookRepostory _bookRepostory ;
        private readonly IUserRepostry _userRepostry ;
       

        public UserBookController(IUserBookRepostory userBookRepostory,
            IBookRepostory bookRepostory,IUserRepostry userRepostry)
        {
            _userBookRepostory = userBookRepostory;
            _bookRepostory = bookRepostory;
            _userRepostry = userRepostry;
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

           var get=await _userBookRepostory.getRenyedBooksbybookId(id);
            if (get == null) {
                return BadRequest("No Book Rental");
            }
            return Ok(get);
        }
        [HttpPost("RentelBook")]
        
        public async Task<IActionResult>create(int userid, int bookid)
        {
           var getbook = await _bookRepostory.GetBookByID(bookid);
            var getuser=await _userRepostry.numberbookfromUser(userid);
            if(getbook ==null )
            {
                return BadRequest("the User or book not found");
            }
            if (getuser.CounUuser > 3)
            {
                return BadRequest("The user Execuod The Alloed Limaet ");
            }
          
           if (getbook.AvulebelQuantity <1 )
            {
                return BadRequest("The Book Not Avelubel");
            }
            var create = new UserBook
            {
                UserId = userid,
                BookId = bookid
            };
            getbook.AvulebelQuantity = getbook.AvulebelQuantity - 1;
            
            _userBookRepostory.create(create, getbook);
            return Ok(create);
        }
        [HttpPut("ReturnBook")]
        public async Task <IActionResult>ReturnBook(int id)
        {
           
            var get=await _userBookRepostory.GetById(id);

            var getbook = await _bookRepostory.GetBookByID(get.BookId);

            get.ReturnTime = DateTime.Now;
            getbook.AvulebelQuantity = getbook.AvulebelQuantity +1;
            await _userBookRepostory.RetarnBook(get);
            await _userBookRepostory.UpdaetQuantity(getbook);

            return Ok(get);
            
        }



    }
}
