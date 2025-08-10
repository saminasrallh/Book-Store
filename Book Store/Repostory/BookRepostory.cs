using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.Model;
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
     
        public async Task<List<GetBookModel>> GetallBook()
        {
            var getbook = _Context.Books.AsNoTracking().Include(x => x.UserBook.Where(x => x.ReturnTime == null))
            .Include(x => x.Auther).Include(x=>x.BookCategory).OrderBy(x => x.Title).Select(getbook=>new GetBookModel
            {
                Title =getbook.Title,
                Description=getbook.Description,
                Quantity = getbook.Quantity,
                Price = getbook.Price,
                Created=getbook.Created,
                CreatedBy = getbook.CreatedBy,
                UpdateBy=getbook.UpdateBy,
                LastUpdated=getbook.LastUpdated,
                BookCategory=getbook.BookCategory.Select(x=>x.Name).ToList(),
                AutherName=getbook.Auther.FName,
            }).ToList();

            return getbook;
        }

        public async Task<Book> GetBookByID(int id)
        {
            var getbook = await _Context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return getbook;
        }

        public async Task<GetBookModel> GetBookByName(string name)
        {
            var getbook = await _Context.Books.Include(x => x.UserBook.Where(x => x.ReturnTime == null))
                 .Include(x => x.Auther).Include(x => x.BookCategory)
                .AsNoTracking().Select(getbook => new GetBookModel
                {
                    Title = getbook.Title,
                    Description = getbook.Description,
                    Quantity = getbook.Quantity,
                    AvulebalQuantity = getbook.AvulebelQuantity,
                    Price = getbook.Price,
                    Created = getbook.Created,
                    CreatedBy = getbook.CreatedBy,
                    UpdateBy = getbook.UpdateBy,
                    LastUpdated = getbook.LastUpdated,
                    BookCategory = getbook.BookCategory.Select(x => x.Name).ToList(),
                    AutherName = getbook.Auther.FName,
                }).FirstOrDefaultAsync(x => x.Title == name);
            return getbook;
        }

        public async Task<Book> CreateBook(Book book)
        {
            await _Context.AddAsync(book);
            await _Context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(Book book)
        {
            _Context.Books.Update(book);
            await _Context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _Context.Books.Update(book);
            await _Context.SaveChangesAsync();
            return book;
        }


    }
}
