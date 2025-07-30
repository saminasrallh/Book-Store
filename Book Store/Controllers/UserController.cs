using Book_Store.Entity;
using Book_Store.IRepostry;
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

        public readonly IUserRepostry _UserRepostry;


        public UserController(IUserRepostry userRepostry)
        {
            _UserRepostry = userRepostry;
        }
        //[Authorize]
        [HttpGet("getalluser")]
       
        public async Task<IActionResult> getalluser()
        {
            var alluser = await _UserRepostry.GetUsers();
            return Ok(alluser);
        }
        [HttpGet("getUSERbyid")]
       // [Authorize (Roles = "employee")]
        public async Task<IActionResult> getUSERbyid(int id)
        {
            var user= await _UserRepostry.GetUsersByID(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Ok("not found");
            }
        }

        

        [HttpGet("getUserbyName")]
        // [Authorize (Roles = "employee")]
        public async Task<IActionResult> getUserbyName(string name)
        {
            var user = await _UserRepostry.GetUsersByName(name);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Ok("not found");
            }
        }
        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task <IActionResult>CreateUser(Usermodel users)
        {
            var create = new Users
            {
            
                FName = users.FName,
                LName = users.LName,
                Email = users.Email,
                Password = users.Password,
                phoneNumber = users.phoneNumber,
                UserName = users.UserName,

            };
            _UserRepostry.CreateUser(create);
            return Ok(create);
        }
        [HttpDelete("DeleteUser")]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var userdelete = await _UserRepostry.GetUsersByID(id);
            _UserRepostry.DeleteUser(userdelete);

            return Ok(userdelete);
        }

        [HttpPut("UpdateUser")]
       // [Authorize(Roles="admin")]
        public async Task<IActionResult>Update(int id,Usermodel users)

        {
            var updateuser =await _UserRepostry.GetUsersByID(id);

          
          
           updateuser.UserName = users.UserName;
            updateuser.Email = users.Email;
            updateuser.Password = users.Password;
            updateuser.phoneNumber=users.phoneNumber;
            updateuser.FName = users.FName;
            updateuser.LName = users.LName;
            
            _UserRepostry.UpdateUser(updateuser);
            return Ok(updateuser);
            
        }
        
        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username,string password)
        {
           var token=await _UserRepostry.GetToken(username, password);
            return Ok(token);
        }

    }
}
