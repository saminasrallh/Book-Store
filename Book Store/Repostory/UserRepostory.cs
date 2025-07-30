using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
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
        public async Task<IEnumerable<Users>> GetUsers()
        {
            var user = await _Context.Users.AsNoTracking().OrderBy(x => x.FName ).ToListAsync();

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
           
           
            _Context.Remove(user);
            _Context.SaveChanges();
            
            return (user);
        }

      

        public async Task<Users> GetUsersByID(int id)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(x => x.Id == id);

          
            return user;
        }

        public async Task<IEnumerable<Users>> GetUsersByName(string name)
        {
            var user = await _Context.Users.AsNoTracking().Where(x=>x.FName==name ||x.LName==name).ToListAsync();

            return (user);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            _Context.Users.Update(user);
            _Context.SaveChanges();
            return user;
        }
        public async Task<IEnumerable> GetToken(string userName, string password)
        {
            var user = await _Context.Users
                 .Where(x => x.UserName == userName && x.Password == password)
                 .AsNoTracking()
                 .Include(x => x.Roles)
                 .FirstOrDefaultAsync();
            if (user == null)
                return ("notfound");

            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.Email)
                        };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            var tokenres = new JwtSecurityTokenHandler().WriteToken(token);

            return (tokenres);
        }

      
    }
}
