using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;

namespace Book_Store.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepostory _categoryRepostory;

        public CategoryServices(ICategoryRepostory categoryRepostory)
        {
            _categoryRepostory = categoryRepostory;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            try
            {
                var getbook = await _categoryRepostory.GetAllCategory();
                return (getbook);
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAndBook()
        {
            try
            {
                var getbook = await _categoryRepostory.GetAllCategoryAndBook();
                return (getbook);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
         }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var getbook = await _categoryRepostory.GetCategoryById(id);
                return (getbook);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            try
            {
                var getbook = await _categoryRepostory.GetCategoryByName(name);
                return (getbook);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
        }

        public object numberbookfromcategory(int id)
        {
            try
            {
                var numbook = _categoryRepostory.numberbookfromcategory(id);
                return (numbook);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }
        public async Task<Category> CreateCategory(string category)
        {
            try
            {
                var create = new Category
                {
                    Name = category


                };
                await _categoryRepostory.CreateCategory(create);
                return (create);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

        public async Task<Category> DeleteCategory(int id)
        {
            try
            {
                var delete = await _categoryRepostory.GetCategoryById(id);
                _categoryRepostory.DeleteCategory(delete);
                return (delete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error: {ex.Message}");
            }
            }

      

        public async Task<Category> UpdateCategory(int id,string category)
        {
            try
            {
                var updatecatigory = await _categoryRepostory.GetCategoryById(id);

                updatecatigory.Name = category;
                _categoryRepostory.UpdateCategory(updatecatigory);

                return (updatecatigory);
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }

        }
    }
}
