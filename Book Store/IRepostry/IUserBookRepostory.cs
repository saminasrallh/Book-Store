using Book_Store.Entity;

namespace Book_Store.IRepostry
{
    public interface IUserBookRepostory
    {
        Task<UserBook>GetById(int id);
    
        Task<IEnumerable<UserBook>> getallRenter();
        Task<IEnumerable< UserBook>> getRenyedBooksbyUserId (int id);
       Task<IEnumerable<UserBook>> getRenyedBooksbybookId (int id);
       Task <UserBook> create (UserBook userBook);
       Task< object> RetarnBook(UserBook userBook);




    }
}

    
