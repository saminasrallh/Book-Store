using Book_Store.Entity;

namespace Book_Store.IServices
{
    public interface IUserBookServices
    {
        Task<UserBook> GetById(int id);

        Task<IEnumerable<UserBook>> getallRenter();
        Task<IEnumerable<UserBook>> getRenyedBooksbyUserId(int id);
        Task<IEnumerable<UserBook>> getRenyedBooksbybookId(int id);
        Task<UserBook> create(UserBook userBook, Book book);
        Task<object> RetarnBook(UserBook userBook);
        Task<object> UpdaetQuantity(Book book);
    }
}
