using Book_Store.Entity;

namespace Book_Store.IRepostry
{
    public interface IBookRepostory
    {
        Task<List<Book>> GetallBook();
        Task<Book> GetBookByID(int id);

        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(Book book);
        Task<Book> GetBookByName(string name);
      
    }
}
