using Book_Store.DBContext;
using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.Model;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Repostory
{
    public class CategoryReposory : ICategoryRepostory
    {
        private readonly AppDBContext _Context;

        public CategoryReposory(AppDBContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var get=await  _Context.Categories.AsNoTracking().ToListAsync();
            return get;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAndBook()
        {
            var get = await _Context.Categories.Include(x=>x.Books).AsNoTracking().ToListAsync();
            return get;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var get =await _Context.Categories.Include(x=>x.Books).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return get;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
           var get =await _Context.Categories.Include(x=>x.Books).AsNoTracking().FirstOrDefaultAsync(x => x.Name==name);
            return get;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _Context.Categories.AddAsync(category);
            await _Context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            _Context.Categories.Update(category);
            await _Context.SaveChangesAsync();
            return category;
        }

  
        public async Task<Category> UpdateCategory(Category category)
        {
            _Context.Categories.Update(category);
            await _Context.SaveChangesAsync();
            return category;
        }
        public async Task<NumberBook?> Numberbookfromcategory(int id)
        {
            return await _Context.Categories.Include(x => x.Books).Where(x => x.Id == id)
                .GroupBy(x=>x.Name)
                .Select(x => new NumberBook
                {
                    Name =  x.Key,
                    Count = x.Count()
            }).FirstOrDefaultAsync();

 
        }
    }
}
