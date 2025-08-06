using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IRepostry
{
    public interface ICategoryRepostory
    {
         Task<IEnumerable<Category>> GetAllCategory();
        Task<IEnumerable<Category>> GetAllCategoryAndBook();

        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(Category category);
        Task<NumberBook> Numberbookfromcategory(int id);
    }
}
