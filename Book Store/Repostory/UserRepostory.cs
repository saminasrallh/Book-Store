using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.Model;
using Book_Store.Repostory;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Store.Repostory
{
    public class UserRepostory : IUserRepostry
    {

        private readonly AppDBContext _Context;
        private readonly IConfiguration _config;

        public UserRepostory(AppDBContext appDBContext, IConfiguration config)
        {
          
            _config = config;
            _Context = appDBContext;
        }
        public async Task<List<GetUserModel>> GetUsers()
        {
            var user = await _Context.Users.AsNoTracking().Include(x=>x.UserBooks)
                .Select(get => new GetUserModel
                {
                    FName = get.FName,
                    LName = get.LName,
                    phoneNumber=get.phoneNumber,
                    CreatedDate = DateTime.UtcNow,
                    UserName = get.UserName,
                    Password= get.Password,
                    Email= get.Email,
                   
                })
                .ToListAsync();

            return (user);
        }
        public async Task<Users> CreateUser(Users user)
        {
           await _Context.AddAsync(user);
            _Context.SaveChanges();
            return user;
        }

        public async Task<Users> DeleteUser(Users user)
        {


                  _Context.Users.Update(user);
            await _Context.SaveChangesAsync();
            
            return (user);
        }

      

        public async Task<Users> GetUsersByID(int id)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(x => x.Id == id);

          
            return user;
        }

        public async Task<List<GetUserModel>> GetUsersByName(string name)
        {
            var user = await _Context.Users.AsNoTracking().Where(x=>x.FName==name ||x.LName==name)
                .Include(x=>x.UserBooks).Select(get => new GetUserModel
                {
                    FName = get.FName,
                    LName = get.LName,
                    phoneNumber = get.phoneNumber,
                    CreatedDate = DateTime.UtcNow,
                    UserName = get.UserName,
                    Password = get.Password,
                    Email = get.Email,
                 
                }).ToListAsync();

            return (user);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            _Context.Users.Update(user);
            _Context.SaveChanges();
            return user;
        }
        public async Task<Users> GetToken(string userName, string password)
        {
            var user = await _Context.Users
                 .Where(x => x.UserName == userName && x.Password == password)
                 .AsNoTracking()
                 .Include(x => x.Roles)
                 .FirstOrDefaultAsync();
                  return user;
           

           
        }
   
        public async Task<numberbookfromUser> numberbookfromUser(int id)
        {

            var numberofbook = new numberbookfromUser();
            var x = await _Context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (x == null)
            {
                return numberofbook = null;
            }

            numberofbook.Fname = x.FName;
            numberofbook.Lname = x.LName;
            numberofbook.CountUuser = _Context.UserBooks.Where(x => x.ReturnTime ==null&&x.UserId==id).Count();
               


            return numberofbook;
        }

    }
}
