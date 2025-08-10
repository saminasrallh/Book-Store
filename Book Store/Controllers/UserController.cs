using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // [Authorize]
        [HttpGet("getalluser")]
       
        public async Task<IActionResult> getalluser()
        {
            var alluser = await _userServices.GetUsers();
            return Ok(alluser);
        }
        [HttpGet("getUSERbyid")]
       // [Authorize (Roles = "employee")]
        public async Task<IActionResult> getUSERbyid(int id)
        {
            var user= await _userServices.GetUsersByID(id);
           
                return Ok(user);
           
        }

        

        [HttpGet("getUserbyName")]
       // [Authorize (Roles = "employee")]
        public async Task<IActionResult> getUserbyName(string name)
        {
            var user = await _userServices.GetUsersByName(name);
           
                return Ok(user);
          
        }
        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task <IActionResult>CreateUser(Usermodel users)
        {
            
          var create=await  _userServices.CreateUser(users);
            return Ok(users);
        }
        [HttpDelete("DeleteUser")]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {

           
          var delete=await  _userServices.DeleteUser(id);

            return Ok(delete);
        }

        [HttpPut("UpdateUser")]
       // [Authorize(Roles="admin")]
        public async Task<IActionResult>Update(int id,Usermodel users)

        {
          var update=await  _userServices.UpdateUser(id,users);
            return Ok(update);
            
        }
        
        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username,string password)
        {
           var token=await _userServices.GetToken(username, password);
            return Ok(token);
        }
        [HttpGet("numberbookfromUser")]
        public async Task<IActionResult> numberbookfromUser(int id)
        {
           var numberbookfromUser= await _userServices.numberbookfromUser(id);
            return Ok(numberbookfromUser);
        }

    }
}
