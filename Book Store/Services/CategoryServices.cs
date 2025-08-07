using Book_Store.Entity;
using Book_Store.IRepostry;
using Book_Store.IServices;
using Book_Store.Model;

namespace Book_Store.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepostory _categoryRepostory;

        public CategoryServices(ICategoryRepostory categoryRepostory)
        {
            _categoryRepostory = categoryRepostory;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            try
            {
                var getCategory = await _categoryRepostory.GetAllCategory();
                if (getCategory == null)
                {
                    throw new ApplicationException($"Error: {"The Categore Not Found"}");
                }
                return (getCategory);
            }
            catch (Exception ex) {
                throw new ApplicationException($" {ex.Message}");
            }
        }

        public async Task<List<Category>> GetAllCategoryAndBook()
        {
            try
            {
                var getCategory = await _categoryRepostory.GetAllCategoryAndBook();
                if (getCategory == null)
                {
                    throw new ApplicationException($"Error: {"The Categore Not Found"}");
                }
                return (getCategory);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
         }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var getCategory = await _categoryRepostory.GetCategoryById(id);
                if (getCategory == null)
                {
                    throw new ApplicationException($"Error: {"The Categore Not Found"}");
                }
                return (getCategory);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            try
            {
                var getCategory = await _categoryRepostory.GetCategoryByName(name);
                if (getCategory == null)
                {
                    throw new ApplicationException($"Error: {"The Categore Not Found"}");
                }
                return (getCategory);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
        }

        public async Task<NumberBook> numberbookfromcategory(int id)
        {
            try
            {
                var numbook =await _categoryRepostory.Numberbookfromcategory(id);
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
                if (delete == null)
                {
                    throw new ApplicationException($"Error: {"The Categore Not Found"}");
                }
                delete.IsDeleted=true;
                delete.DeletedTime = DateTime.Now;
                await _categoryRepostory.DeleteCategory(delete);
                return (delete);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($" {ex.Message}");
            }
            }

      

        public async Task<Category> UpdateCategory(int id,string category)
        {
            try
            {
                var updatecatigory = await _categoryRepostory.GetCategoryById(id);

                updatecatigory.Name = category;
               await _categoryRepostory.UpdateCategory(updatecatigory);

                return (updatecatigory);
            }
            catch (Exception ex) {
                throw new ApplicationException($"Error: {ex.Message}");
            }

        }
    }
}
