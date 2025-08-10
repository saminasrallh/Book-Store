using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IRepostry
{
    public interface IBookRepostory
    {
        Task<List<GetBookModel>> GetallBook();
        Task<Book> GetBookByID(int id);

        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(Book book);
        Task<GetBookModel> GetBookByName(string name);
      
    }
}
