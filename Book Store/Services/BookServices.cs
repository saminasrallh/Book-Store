


using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;

namespace Book_Store.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepostory _bookRepostory;
        private readonly IAutherRepostory _autherRepostory;

        public BookServices(IBookRepostory bookRepostory, IAutherRepostory autherRepostory)
        {
            _bookRepostory = bookRepostory;
            _autherRepostory = autherRepostory;
        }
        public async Task<IEnumerable<Book>> GetallBook()
        {
            try
            {
                var getbook = await _bookRepostory.GetallBook();
                if (getbook == null)
                {
                    throw new ApplicationException($"Error: {"The Book Not Found"}");
                }
                return getbook;
            }
            catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }

        public async Task<Book> GetBookByID(int id)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByID(id);
                if (getbook == null)
                {
                    throw new ApplicationException($" {"The Book Not Found"}");
                }
                return getbook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }

        public async Task<Book> GetBookByName(string name)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByName(name);
                if (getbook == null)
                {
                    throw new ApplicationException($" {"The Book Not Found"}");
                }
                return getbook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }
        public async Task<Book> CreateBook(BookModelCreate book)
        {
            try
            {
                
                var create = new Book
                {
                    Title = book.Title,
                    Description = book.Description,
                    Quantity = book.Quantity,
                    Price = book.Price,
                    CreatedBy = book.CreatedBy,
                    AutherId = book.AutherId,
                    AvulebelQuantity = book.Quantity,
                    Created=DateTime.Now,


                };
               var Auther=await _autherRepostory.GetAutherByID((int)create.AutherId);
                
                if (create.AutherId==0||Auther==null)
                {
                    throw new ApplicationException($"Error: {"The Auther Not Found"}");
                }
                await _bookRepostory.CreateBook(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }

        public async Task<Book> DeleteBook(int id)
        {
            try
            {
                var delete = await _bookRepostory.GetBookByID(id);
                if (delete == null)
                {
                    throw new ApplicationException($"Error: {"The Book Not Found"}");
                }
                delete.IsDeleted = true;
                delete.DeletedTime = DateTime.Now;
                await _bookRepostory.DeleteBook(delete);
                return (delete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }


        public async Task<Book> UpdateBook(int id, UpdateBookModel book)
        {
            try
            {

                var updatebook = await _bookRepostory.GetBookByID(id);
                if (updatebook == null)
                {
                    throw new ApplicationException($"Error: {"The Book Not Found"}");
                }

                updatebook.Title = book.Title;
                updatebook.Description = book.Description;
                updatebook.Quantity = book.Quantity;
                updatebook.Price = book.Price;
                updatebook.UpdateBy = book.UpdateBy;
                updatebook.LastUpdated = DateTime.Now;
                updatebook.AvulebelQuantity = book.Quantity;
                await _bookRepostory.UpdateBook(updatebook);

                return (updatebook);
            }
            catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }
    }
}
