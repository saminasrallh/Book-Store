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

        public async Task<List<UserBook>> getallRenter()
        {
            try
            {
                var getallRenter = await _userBookRepostory.getallRenter();
                if(getallRenter == null)
                {
                    throw new ApplicationException($"Error: {"No Book Rental"}");
                }
                return (getallRenter);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<List<UserBook>> getRenyedBooksbyUserId(int id)
        {
            try
            {
                var getuser = await _userBookRepostory.getRenyedBooksbyUserId(id);
                if (getuser == null)
                {
                    throw new ApplicationException($"Error: {"The User Not Found"}");
                }
                return getuser;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }

        }
        public async Task<List<UserBook>> getRenyedBooksbybookId(int id)
        {
            try
            {
                var getbook = await _userBookRepostory.getRenyedBooksbybookId(id);
                if (getbook == null)
                {
                    throw new ApplicationException($"Error: {"The Book Not Found"}");
                }
                return getbook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }
        public async Task<UserBook> create(int userid, int bookid)
        {
            try
            {
                var getbook = await _bookRepostory.GetBookByID(bookid);
                var getuser = await _userRepostry.numberbookfromUser(userid);
                if (getbook == null || getuser == null)
                {
                    throw new ApplicationException($"Error: {"The Book Or User Not Found"}");
                }
               
                if (getuser.CountUuser >= 3 ) {
                  throw  new ApplicationException($"Error: {"The Book Not Avelabel"}"); 
                   
                }
                if (getbook.AvulebelQuantity < 1)
                {
                    throw new ApplicationException($"Error: {"The Book Not Avelabel"}"); 
                }


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
                throw new ApplicationException($" {ex.Message}");

            }
        }

        

        public async Task<UserBook> GetById(int id)
        {
            try
            {
                var getusrebook = await _userBookRepostory.GetById(id);
                if (getusrebook == null)
                {
                    throw new ApplicationException($"Error: {"The Book Not Found"}");
                }
                return getusrebook;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }

        public async Task<UserBook> RetarnBook(int id)
        {
            try
            {
                var getuserbook = await _userBookRepostory.GetByIdUserbook(id);
                if(getuserbook.ReturnTime != null)
                {
                    throw new ApplicationException($"Error: {"The Book its Retarn"}");
                }

                var getbook = await _bookRepostory.GetBookByID(getuserbook.BookId);

                getuserbook.ReturnTime = DateTime.Now;
                getbook.AvulebelQuantity = getbook.AvulebelQuantity + 1;
                await _userBookRepostory.RetarnBook(getuserbook);
                await _userBookRepostory.UpdateQuantity(getbook);

                return (getuserbook);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }
    }
}
