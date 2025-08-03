using Book_Store.Entity;
using Book_Store.Model;
using System.Collections;

namespace Book_Store.IServices
{
    public interface IUserServices
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUsersByID(int id);

        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> DeleteUser(Users users);

        Task<IEnumerable<Users>> GetUsersByName(string name);
        Task<IEnumerable> GetToken(string name, string password);
        Task<numberbookfromUser> numberbookfromUser(int id);
    }
}
