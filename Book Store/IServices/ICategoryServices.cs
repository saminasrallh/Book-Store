using Book_Store.Entity;

namespace Book_Store.IServices
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<IEnumerable<Category>> GetAllCategoryAndBook();

        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(Category category);
        public object numberbookfromcategory(int id);
    }
}
