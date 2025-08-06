using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
       private readonly IAutherServices _autherServices;

        public AutherController(IAutherServices autherServices)
        {
            _autherServices = autherServices;
        }

        [HttpGet("getallAuther")]
        public async Task<IActionResult> GetallAuther()
        {
            var getAuther = await _autherServices.GetAuther();
            return Ok(getAuther);
        }
        [HttpGet("GetallAutherِAndBook")]
        public async Task<IActionResult> GetallAutherAndBook()
        {
            var getAuther = await _autherServices.GetAutherِAndBook();
            return Ok(getAuther);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> getAutherbyid(int id)
        {
            var getAuther = await _autherServices.GetAutherByID(id);
            
            return Ok(getAuther);

        }
        [HttpGet("getbyname")]
        public async Task<IActionResult> getAutherbyName(string name)
        {
            var getAuther = await _autherServices.GetAutherByName(name);
                return Ok(getAuther);
        }
        [HttpGet("numberbookfromauther")]
        public async Task<IActionResult> numberbookfromauther(int id)
        {
            var get=await _autherServices.numberbookfromauther(id);
            return Ok(get);
        }

        [HttpPost("CreateAuther")]
        public async Task<IActionResult> CreateAuther(AutherModel auther)
        {
           
           var create= await _autherServices.CreateAuther(auther);
            return Ok(create);

        }
        [HttpDelete("DeleteAuther")]
        public async Task<IActionResult> DeleteAuther(int id)
        {
         var delete= await _autherServices.DeleteAuther(id);
            return Ok(delete);

        }
        [HttpPut("UpdateAuther")]
        public async Task<IActionResult> UpdateAuther(int id,AutherModel auther)

        {
          var update= await _autherServices.UpdateAuther(id, auther);

            return Ok(update);
        }
      




    }
}
