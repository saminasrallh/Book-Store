
using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IServices
{
    public interface IAutherServices
    {
        Task<List<AutherModel>> GetAuther();
        Task<List<GetAutherModel>> GetAutherِAndBook();
        Task<Auther> GetAutherByID(int id);

        Task<Auther> CreateAuther(AutherModel auther);
        Task<Auther> UpdateAuther(int id, AutherModel auther);
        Task<Auther> DeleteAuther(int id);
        Task<GetAutherModel> GetAutherByName(string name);
        Task<NumberBook> numberbookfromauther(int id);
       
    }
}
