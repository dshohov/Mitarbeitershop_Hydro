using Mitarbeitershop_Hydro.Models;
using Mitarbeitershop_Hydro.ViewModels;

namespace Mitarbeitershop_Hydro.IServices
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(string id);
        public Task AddCategoryAsync(AddCategoryViewModel addCategoryViewModel);
        public Task DeleteCategoryAsync(string id);
        public Task UpdateCategoryAsync(Category category);
    }
}
