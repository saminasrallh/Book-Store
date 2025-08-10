using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IRepostry
{
    public interface IAutherRepostory
    {
        Task<List<AutherModel>> GetAuther();
        Task<List<GetAutherModel>> GetAutherِAndBook();
        Task<Auther> GetAutherByID(int id);

        Task<Auther> CreateAuther(Auther auther);
        Task<Auther> UpdateAuther(Auther auther);
        Task<Auther> DeleteAuther(Auther auther);
        Task<GetAutherModel> GetAutherByName(string name);
        Task<NumberBook> numberbookfromauther(int id);
       
    }
}
