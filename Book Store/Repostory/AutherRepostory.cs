using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Repostory
{
    public class AutherRepostory : IAutherRepostory
    {
        private readonly AppDBContext _dbContext;

        public AutherRepostory(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Auther>> GetAutherِAndBook()
        {
            var get=await _dbContext.Authers.Include(x=>x.books).AsNoTracking().ToListAsync();
            return get;
        }

        public async Task<IEnumerable<Auther>> GetAuther()
        {
            var get = await _dbContext.Authers.AsNoTracking().ToListAsync();
            return get;
        }


        public async Task<Auther> GetAutherByID(int id)
        {
            var get = await _dbContext.Authers.Include(x=>x.books).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
          
            return get;
        }

        public async Task<Auther> GetAutherByName(string name)
        {
            var get = await _dbContext.Authers.Include(x => x.books).AsNoTracking()
                .FirstOrDefaultAsync(x => x.FName == name || x.LName == name);
            return get;
        }

        public async Task<Auther> CreateAuther(Auther auther)
        {
           await _dbContext.Authers.AddAsync(auther);
            _dbContext.SaveChanges();
            return auther;
        }

        public async Task<Auther> DeleteAuther(Auther auther)
        {
           _dbContext.Authers.Remove(auther);
            _dbContext.SaveChangesAsync() ;
            return auther;
        }

    
        public async Task<Auther> UpdateAuther(Auther auther)
        {
            _dbContext.Authers.Update(auther);
            _dbContext.SaveChanges();
            return auther;
        }

        public object numberbookfromauther(int id)
        {

            var number = _dbContext.Authers.Where(x=>x.Id==id).Select(a => new
            {
                Fname = a.FName,
                countBook = a.books.Count,
            });
            
            return number;
        }
    }
}
