using Book_Store.Entity;
using Book_Store.Model;

namespace Book_Store.IServices
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllCategory();
        Task<List<Category>> GetAllCategoryAndBook();

        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> CreateCategory(string category);
        Task<Category> UpdateCategory(int id,string category);
        Task<Category> DeleteCategory(int id);
       Task<NumberBook> numberbookfromcategory(int id);
    }
}
