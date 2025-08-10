using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Book_Store.Services
{
    public class UserServices : IUserServices
    {

        public readonly IUserRepostry _UserRepostry;
        private readonly IConfiguration _config;


        public UserServices(IUserRepostry userRepostry, IConfiguration config)
        {
            _UserRepostry = userRepostry;
            _config = config;
        }
        public async Task<List<GetUserModel>> GetUsers()
        {
            try
            {
                var alluser = await _UserRepostry.GetUsers();
                if (alluser == null)
                {
                    throw new ApplicationException($"Error: {"The User Not Found"}");
                }
                return (alluser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<Users> GetUsersByID(int id)
        {
            try
            {
                var user = await _UserRepostry.GetUsersByID(id);
                if (user == null)
                {
                    throw new ApplicationException($"Error: {"The User Not Found"}");
                }
                return user;
            } catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<List<GetUserModel>> GetUsersByName(string name)
        {
            try
            {
                var user = await _UserRepostry.GetUsersByName(name);
                if (user.Count() == 0)
                {
                    throw new ApplicationException($"Error: {"The User Not Found"}");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }
        public async Task<Users> CreateUser(CreateUserModel user)
        {
            try
            {
                var create = new Users
                {

                    FName = user.FName,
                    LName = user.LName,
                    Email = user.Email,
                    Password = user.Password,
                    phoneNumber = user.phoneNumber,
                    UserName = user.UserName,
                    CreatedDate= DateTime.Now,

                };
                await _UserRepostry.CreateUser(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }

        public async Task<Users> DeleteUser(int id)
        {
            try
            {
                var userdelete = await _UserRepostry.GetUsersByID(id);
                if (userdelete == null)
                {
                    throw new ApplicationException($"Error: {"The User Not Found"}");
                }
                userdelete.IsDeleted = true;
                userdelete.DeletedTime= DateTime.Now;
               await _UserRepostry.DeleteUser(userdelete);

                return (userdelete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }

        public async Task<IEnumerable> GetToken(string username, string password)

        {
            try
            {
                var user = await _UserRepostry.GetToken(username, password);
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
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }

            }


        public async Task<numberbookfromUser> numberbookfromUser(int id)
        {
            try
            {
                var numberfromuser = await _UserRepostry.numberbookfromUser(id);
                if(numberfromuser == null)
                {
                    throw new ApplicationException($"Error:The User Not Found");
                }
                return (numberfromuser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }

            }

        public async Task<Users> UpdateUser(int id, CreateUserModel users)
        {
            try
            {
                var updateuser = await _UserRepostry.GetUsersByID(id);



                updateuser.UserName = users.UserName;
                updateuser.Email = users.Email;
                updateuser.Password = users.Password;
                updateuser.phoneNumber = users.phoneNumber;
                updateuser.FName = users.FName;
                updateuser.LName = users.LName;

               await _UserRepostry.UpdateUser(updateuser);
                return (updateuser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }
    }
}
