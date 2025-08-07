using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IServices
{
    public interface IBookServices
    {
        Task<List<Book>> GetallBook();
        Task<Book> GetBookByID(int id);

        Task<Book> CreateBook(BookModelCreate book);
        Task<Book> UpdateBook(int id,UpdateBookModel book);
        Task<Book> DeleteBook(int id);
        Task<Book> GetBookByName(string name);
    }
}
