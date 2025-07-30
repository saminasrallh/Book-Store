using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IAutherRepostory _repostory;

        public AutherController(IAutherRepostory repostory)
        {
            _repostory = repostory;
        }
        [HttpGet("getallAuther")]
        public async Task<IActionResult> GetallAuther()
        {
            var getAuther = await _repostory.GetAuther();
            return Ok(getAuther);
        }
        [HttpGet("GetAutherِAndBook")]
        public async Task<IActionResult> GetallAutherAndBook()
        {
            var getAuther = await _repostory.GetAutherِAndBook();
            return Ok(getAuther);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> getAutherbyid(int id)
        {
            var getAuther = await _repostory.GetAutherByID(id);
            if (getAuther != null)
            {
                return Ok(getAuther);
            }
            else
            {
                return Ok("not found");
            }
            return Ok(getAuther);

        }
        [HttpGet("getbyname")]
        public async Task<IActionResult> getAutherbyName(string name)
        {
            var getAuther = await _repostory.GetAutherByName(name);
            if (getAuther != null)
            {
                return Ok(getAuther);
            }
            else
            {
                return Ok("not found");
            }
        }
        [HttpGet("numberbookfromauther")]
        public object numberbookfromauther(int id)
        {
            return _repostory.numberbookfromauther(id);
        }

        [HttpPost("CreateAuther")]
        public async Task<IActionResult> CreateAuther(AutherModel auther)
        {
            var create = new Auther
            {
                FName=auther.FName,
                LName=auther.LName,
                Country=auther.Country,
                BirthDay=auther.BirthDay,


            };
            await _repostory.CreateAuther(create);
            return Ok(create);

        }
        [HttpDelete("DeleteAuther")]
        public async Task<IActionResult> DeleteAuther(int id)
        {
            var delete = await _repostory.GetAutherByID(id);
           _repostory.DeleteAuther(delete);
            return Ok(delete);

        }
        [HttpPut("UpdateAuther")]
        public async Task<IActionResult> UpdateAuther(int id,AutherModel auther)

        {
            

            var update = await _repostory.GetAutherByID(id);

            update.FName = auther.FName;
            update.LName = auther.LName;
            update.Country = auther.Country;
            update.BirthDay = auther.BirthDay;


            
            _repostory.UpdateAuther(update);

            return Ok(update);
        }
      




    }
}
