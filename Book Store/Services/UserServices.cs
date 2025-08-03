using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;
using System.Collections;

namespace Book_Store.Services
{
    public class UserServices : IUserServices
    {

        public readonly IUserRepostry _UserRepostry;


        public UserServices(IUserRepostry userRepostry)
        {
            _UserRepostry = userRepostry;
        }
        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
                var alluser = await _UserRepostry.GetUsers();
                return (alluser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<Users> GetUsersByID(int id)
        {
            try
            {
                var user = await _UserRepostry.GetUsersByID(id);
                return user;
            } catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Users>> GetUsersByName(string name)
        {
            try
            {
                var user = await _UserRepostry.GetUsersByName(name);
                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }
        public async Task<Users> CreateUser(Usermodel user)
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

                };
                await _UserRepostry.CreateUser(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

        public async Task<Users> DeleteUser(int id)
        {
            try
            {
                var userdelete = await _UserRepostry.GetUsersByID(id);
                _UserRepostry.DeleteUser(userdelete);

                return (userdelete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

        public async Task<IEnumerable> GetToken(string username, string password)
        {
            try
            {
                var token = await _UserRepostry.GetToken(username, password);
                return (token);
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
                return (numberfromuser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }

            }

        public async Task<Users> UpdateUser(int id, Usermodel users)
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

                _UserRepostry.UpdateUser(updateuser);
                return (updateuser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }
    }
}
