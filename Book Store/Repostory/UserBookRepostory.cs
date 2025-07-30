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
            var get=await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return get;
        }
        public async Task<IEnumerable<UserBook>> getallRenter()
        {
        var get=await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().Where(x=>x.ReturnTime==null).ToListAsync();
            return get;
        }

        public async Task<IEnumerable<UserBook>> getRenyedBooksbybookId(int id)
        {
           var getbook=await _Context.UserBooks.Include(x => x.Book).Include(x => x.User)
               .Where(x=>x.BookId==id && x.ReturnTime==null).ToListAsync();
            return getbook;
        }

        public async Task<IEnumerable<UserBook>> getRenyedBooksbyUserId(int id)
        {
           var getuser=await _Context.UserBooks.Include(x=>x.Book).Include(x=>x.User)
                .AsNoTracking().Where(x=>x.UserId==id&&x.ReturnTime==null).ToListAsync();
            return getuser;
        }

        public async Task<UserBook> create(UserBook userBook)
        {
           _Context.UserBooks.AddAsync(userBook);
            _Context.SaveChanges();
            return userBook;

        }



        public async Task<object> RetarnBook(UserBook userBook)
        {
          
            _Context.UserBooks.Update(userBook);
            _Context.SaveChanges();

            return userBook;
        }

    
        
    }
}
