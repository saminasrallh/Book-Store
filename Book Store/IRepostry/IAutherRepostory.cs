using Book_Store.Entity;

namespace Book_Store.IRepostry
{
    public interface IAutherRepostory
    {
        Task<IEnumerable<Auther>> GetAuther();
        Task<IEnumerable<Auther>> GetAutherِAndBook();
        Task<Auther> GetAutherByID(int id);

        Task<Auther> CreateAuther(Auther auther);
        Task<Auther> UpdateAuther(Auther auther);
        Task<Auther> DeleteAuther(Auther auther);
        Task<Auther> GetAutherByName(string name);
        public object numberbookfromauther(int id);
    }
}
