using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class UserBookController : ControllerBase
    {
       private readonly IUserBookServices _userBookServices;

        public UserBookController(IUserBookServices userBookServices)
        {
            _userBookServices = userBookServices;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getall()
        {
          var get=  await _userBookServices.getallRenter();
            return Ok(get);
        }
        [HttpGet("getRenyedBooksbyUserId")]
        public async Task <IActionResult> getRenyedBooksbyUserId(int id)
        {
           var getbyuser= await _userBookServices.getRenyedBooksbyUserId(id);
       
            return Ok(getbyuser);
        }
        [HttpGet("getRenyedBooksbybookId")]
        public async Task <IActionResult> getRenyedBooksbybookId(int id)
        {

           var getbybook=await _userBookServices.getRenyedBooksbybookId(id);
        
            return Ok(getbybook);
        }
        [HttpPost("RentelBook")]
        
        public async Task<IActionResult>create(int userid, int bookid)
        {
          
         var create=  await _userBookServices.create(userid, bookid);
            return Ok(create);
        }
        [HttpPut("ReturnBook")]
        public async Task <IActionResult>ReturnBook(int id)
        {
         var returnbook= await _userBookServices.RetarnBook(id);
            return Ok(returnbook);
            
        }



    }
}
