using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IRepostry
{
    public interface IUserBookRepostory
    {
        Task<UserBook>GetById(int id);
        Task<UserBook> GetByIdUserbook(int id);
        Task<List<GetUserBookModel>> getallRenter();
        Task<List< UserBook>> getRenyedBooksbyUserId (int id);
       Task<List<UserBook>> getRenyedBooksbybookId (int id);
       Task <UserBook> create (UserBook userBook,Book book);
       Task<UserBook> RetarnBook(UserBook userBook);
        Task<Book> UpdateQuantity(Book book);




    }
}

    
