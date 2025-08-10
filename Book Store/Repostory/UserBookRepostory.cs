using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Repostory
{
    public class UserBookRepostory : IUserBookRepostory
    {
      
        private readonly AppDBContext _Context;
        private readonly IBookRepostory _bookRepostory;
        public UserBookRepostory(AppDBContext appDBContext, IBookRepostory bookRepostory)
        {
            _Context = appDBContext;
            _bookRepostory = bookRepostory;
        }
        public async Task<UserBook> GetById(int id)
        {
            var getusarbook=await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return getusarbook;
        }
        public async Task<UserBook>GetByIdUserbook(int id)
        {
            var getusarbook = await _Context.UserBooks.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return getusarbook;
        }
        public async Task<List<UserBook>> getallRenter()
        {
        var getusarbook = await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().Where(x=>x.ReturnTime==null).ToListAsync();
            return getusarbook;
        }

        public async Task<List<UserBook>> getRenyedBooksbybookId(int id)
        {
           var getbook=await _Context.UserBooks.Include(x => x.Book).Include(x => x.User).AsNoTracking()
               .Where(x=>x.BookId==id && x.ReturnTime==null).ToListAsync();
            return getbook;
        }

        public async Task<List<UserBook>> getRenyedBooksbyUserId(int id)
        {
           var getuser=await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().Where(x=>x.UserId==id&&x.ReturnTime==null).ToListAsync();
            return getuser;
        }

        public async Task<UserBook> create(UserBook userBook, Book book)
        {
           
            await _Context.UserBooks.AddAsync(userBook);
                  _Context.Books.Update(book);
            await _Context.SaveChangesAsync();
            return userBook;

        }



        public async Task<UserBook> RetarnBook(UserBook userBook)
        {
           
            _Context.UserBooks.Update(userBook);
            await _Context.SaveChangesAsync();

            return userBook;
        }
        public async Task<Book>UpdateQuantity(Book book)
        {
           
            _Context.Books.Update(book);
           await _Context.SaveChangesAsync();

            return book;
        }
    
        
    }
}
