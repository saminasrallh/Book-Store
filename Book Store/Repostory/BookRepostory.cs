using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Book_Store.Repostory
{
    public class BookRepostory : IBookRepostory
    {
        private readonly AppDBContext _Context;

        public BookRepostory(AppDBContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Book>> GetallBook()
        {
            var getbook=await _Context.Books.AsNoTracking().Include(x=>x.UserBook .Where(x=>x.ReturnTime==null))
                .Include(x=>x.Auther).OrderBy(x => x.Title).ToListAsync();
            return getbook;
        }

        public async Task<Book> GetBookByID(int id)
        {
           var getbook= await _Context.Books.Include(x=>x.UserBook.Where(x=>x.ReturnTime==null))
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
           
            return getbook;
        }
      
        public async Task<Book> GetBookByName(string name)
        {
            var getbook=await _Context.Books.Include(x=>x.UserBook.Where(x => x.ReturnTime == null))
                .AsNoTracking() .FirstOrDefaultAsync(x=>x.Title == name);
            return getbook;
        }

        public async Task<Book> CreateBook(Book book)
        {
          await _Context.AddAsync(book);
            _Context.SaveChanges();
            return book;
        }

        public async Task<Book> DeleteBook(Book book)
        {
            _Context.Books.Remove(book);
            _Context.SaveChanges();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
             _Context.Books.Update(book);
            _Context.SaveChanges();
            return book;
        }

       
    }
}
