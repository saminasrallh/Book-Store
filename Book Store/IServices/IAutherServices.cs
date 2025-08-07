
using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IServices
{
    public interface IAutherServices
    {
        Task<List<Auther>> GetAuther();
        Task<List<Auther>> GetAutherِAndBook();
        Task<Auther> GetAutherByID(int id);

        Task<Auther> CreateAuther(AutherModel auther);
        Task<Auther> UpdateAuther(int id, AutherModel auther);
        Task<Auther> DeleteAuther(int id);
        Task<Auther> GetAutherByName(string name);
        Task<NumberBook> numberbookfromauther(int id);
       
    }
}
