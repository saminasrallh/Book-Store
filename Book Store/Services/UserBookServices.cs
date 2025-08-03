using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using System.Net;

namespace Book_Store.Services
{
    public class UserBookServices : IUserBookServices
    {
        private readonly IUserBookRepostory _userBookRepostory;
        private readonly IBookRepostory _bookRepostory;
        private readonly IUserRepostry _userRepostry;

        public UserBookServices(IUserBookRepostory userBookRepostory,
          IBookRepostory bookRepostory, IUserRepostry userRepostry)
        {
            _userBookRepostory = userBookRepostory;
            _bookRepostory = bookRepostory;
            _userRepostry = userRepostry;
        }

        public async Task<IEnumerable<UserBook>> getallRenter()
        {
            try
            {
                var get = await _userBookRepostory.getallRenter();
                return (get);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<IEnumerable<UserBook>> getRenyedBooksbyUserId(int id)
        {
            try
            {
                var get = await _userBookRepostory.getRenyedBooksbyUserId(id);
                return get;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }

        }
        public async Task<IEnumerable<UserBook>> getRenyedBooksbybookId(int id)
        {
            try
            {
                var get = await _userBookRepostory.getRenyedBooksbybookId(id);
                return get;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }
        public async Task<UserBook> create(int userid, int bookid)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByID(bookid);
                var getuser = await _userRepostry.numberbookfromUser(userid);
              
             
                var create = new UserBook
                {
                    UserId = userid,
                    BookId = bookid,
                    RentalTime = DateTime.Now,
                    deadline = DateTime.Now.AddMonths(1),
                    
                };
                getbook.AvulebelQuantity = getbook.AvulebelQuantity - 1;

                await _userBookRepostory.create(create, getbook);
                return (create);
            }catch(Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");

            }
        }

        

        public async Task<UserBook> GetById(int id)
        {
            try
            {
                var getbyid = await _userBookRepostory.GetById(id);
                return getbyid;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }

        public async Task<object> RetarnBook(int id)
        {
            try
            {
                var get = await _userBookRepostory.GetById(id);

                var getbook = await _bookRepostory.GetBookByID(get.BookId);

                get.ReturnTime = DateTime.Now;
                getbook.AvulebelQuantity = getbook.AvulebelQuantity + 1;
                await _userBookRepostory.RetarnBook(get);
                await _userBookRepostory.UpdaetQuantity(getbook);

                return (get);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }
    }
}
