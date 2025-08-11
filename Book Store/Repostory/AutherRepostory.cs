using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Book_Store.Repostory
{
    public class AutherRepostory : IAutherRepostory
    {
        private readonly AppDBContext _dbContext;

        public AutherRepostory(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetAutherModel>> GetAutherِAndBook()
        {
            var getauther=await _dbContext.Authers.Include(x=>x.books).AsNoTracking().Select(get=>new GetAutherModel
            {
                LName=get.LName,
                FName=get.FName,
                BirthDay=get.BirthDay,
                Country=get.Country,
                books=get.books.Select(bookname=>bookname.Title).ToList(),
                
            }).ToListAsync();
            return getauther;
           
        }

        public async Task<List<AutherModel>> GetAuther()
        {
            var getauther = await _dbContext.Authers.AsNoTracking().Select(get => new AutherModel
            {
                FName = get.FName,
                LName = get.LName,
                Country = get.Country,
                BirthDay = get.BirthDay,
            }).ToListAsync();
            return getauther;
        }


        public async Task<Auther> GetAutherByID(int id)
        {
            var getauther = await _dbContext.Authers.Include(x=>x.books).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
          
            return getauther;
        }

        public async Task<GetAutherModel> GetAutherByName(string name)
        {
            var getauther = await _dbContext.Authers.Include(x => x.books).AsNoTracking().Select(get => new GetAutherModel
            {
                LName = get.LName,
                FName = get.FName,
                BirthDay = get.BirthDay,
                Country = get.Country,
                books = get.books.Select(bookname => bookname.Title).ToList(),

            })
                .FirstOrDefaultAsync(x => x.FName == name || x.LName == name);
            return getauther;
        }

        public async Task<Auther> CreateAuther(Auther auther)
        {
           await _dbContext.Authers.AddAsync(auther);
           await _dbContext.SaveChangesAsync();
            return auther;
        }

        public async Task<Auther> DeleteAuther(Auther auther)
        {
           _dbContext.Authers.Update(auther);
           await _dbContext.SaveChangesAsync() ;
            return auther;
        }

    
        public async Task<Auther> UpdateAuther(Auther auther)
        {
            _dbContext.Authers.Update(auther);
           await _dbContext.SaveChangesAsync();
            return auther;
        }

        public async Task<NumberBook> numberbookfromauther(int id)
        {

            var numberbookfromauther = _dbContext.Authers.Where(x=>x.Id==id).Select(num => new NumberBook
            {
                Name = num.FName,
                Count = num.books.Count,
            }).FirstOrDefault();
            
            return numberbookfromauther;
        }

       
    }
}
