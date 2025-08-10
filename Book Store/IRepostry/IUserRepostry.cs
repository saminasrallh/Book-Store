using Book_Store.Entity;
using Book_Store.Model;
using System.Collections;

namespace Book_Store.IRepostry
{
    public interface IUserRepostry
    {
        Task <List<GetUserModel>> GetUsers ();
        Task<Users> GetUsersByID(int id);

        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> DeleteUser(Users users);
       
        Task<List<GetUserModel>> GetUsersByName(string name);
        Task <Users> GetToken(string name, string password);
        Task< numberbookfromUser> numberbookfromUser (int id);

    }
}
