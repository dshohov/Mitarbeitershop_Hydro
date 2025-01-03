using Mitarbeitershop_Hydro.Models;
using Mitarbeitershop_Hydro.ViewModels;

namespace Mitarbeitershop_Hydro.IServices
{
    public interface ISubCategoryService
    {
        public Task<List<SubCategory>> GetSubCategoriesAsync();
        public Task<SubCategory> GetSubCategoryByIdAsync(string id);
        public Task AddSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel);
        public Task DeleteSubCategoryAsync(string id);
        public Task UpdateSubCategoryAsync(SubCategory subCategory);
    }
}
