using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IServices
{
    public interface IUserBookServices
    {
        Task<UserBook> GetById(int id);

        Task<List<GetUserBookModel>> getallRenter();
        Task<List<UserBook>> getRenyedBooksbyUserId(int id);
        Task<List<UserBook>> getRenyedBooksbybookId(int id);
        Task<UserBook> create(int userid,int bookid);
        Task<UserBook> RetarnBook(int id);
      
    }
}
