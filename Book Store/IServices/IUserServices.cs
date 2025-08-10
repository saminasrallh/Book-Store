using Book_Store.Entity;
using Book_Store.Model;
using System.Collections;

namespace Book_Store.IServices
{
    public interface IUserServices
    {
        Task<List<GetUserModel>> GetUsers();
        Task<Users> GetUsersByID(int id);

        Task<Users> CreateUser(Usermodel user);
        Task<Users> UpdateUser(int id,Usermodel user);
        Task<Users> DeleteUser(int id);

        Task<List<GetUserModel>> GetUsersByName(string name);
        Task<IEnumerable> GetToken(string username, string password);
        Task<numberbookfromUser> numberbookfromUser(int id);
    }
}
