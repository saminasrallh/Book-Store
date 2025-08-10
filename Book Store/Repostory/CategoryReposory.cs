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
        public async Task<List<string>> GetAllCategory()
        {
            var getCategories = await  _Context.Categories.AsNoTracking().Select(x=>x.Name).ToListAsync();
            return getCategories;
        }
        public async Task<List<GetCategory>> GetAllCategoryAndBook()
        {
            var getCategoriesandbook = await _Context.Categories.Include(x=>x.Books).AsNoTracking()
                .Select(get=>new GetCategory
                {
                    Name = get.Name,
                    Books=get.Books.Select(x=>x.Title).ToList(),

                }).ToListAsync();
            return getCategoriesandbook;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var getCategories = await _Context.Categories.Include(x=>x.Books).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            return getCategories;
        }

        public async Task<GetCategory> GetCategoryByName(string name)
        {
           var getCategories = await _Context.Categories.Include(x=>x.Books).AsNoTracking()
                .Select(getCategories=> new GetCategory
                {
                    Name = getCategories.Name,
                    Books=getCategories.Books.Select(x=>x.Title).ToList()
                })
                .FirstOrDefaultAsync(x => x.Name==name);
            return getCategories;
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
