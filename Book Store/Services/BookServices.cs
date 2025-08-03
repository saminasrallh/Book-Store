using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;

namespace Book_Store.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepostory _bookRepostory;

        public BookServices(IBookRepostory bookRepostory)
        {
            _bookRepostory = bookRepostory;
        }
        public async Task<IEnumerable<Book>> GetallBook()
        {
            try
            {
                var getbook = await _bookRepostory.GetallBook();
                return getbook;
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }

        public async Task<Book> GetBookByID(int id)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByID(id);
                return getbook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

        public async Task<Book> GetBookByName(string name)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByName(name);
                return getbook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
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


                };
                await _bookRepostory.CreateBook(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

        public async Task<Book> DeleteBook(int id)
        {
            try
            {
                var delete = await _bookRepostory.GetBookByID(id);
                _bookRepostory.DeleteBook(delete);
                return (delete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }


        public async Task<Book> UpdateBook(int id, UpdateBookModel book)
        {
            try
            {

                var updatebook = await _bookRepostory.GetBookByID(id);

                updatebook.Title = book.Title;
                updatebook.Description = book.Description;
                updatebook.Quantity = book.Quantity;
                updatebook.Price = book.Price;
                updatebook.UpdateBy = book.UpdateBy;
                updatebook.LastUpdated = DateTime.Now;
                updatebook.AvulebelQuantity = book.Quantity;
                _bookRepostory.UpdateBook(updatebook);

                return (updatebook);
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
    }
}
