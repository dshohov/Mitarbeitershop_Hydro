using Mitarbeitershop_Hydro.Models;

namespace Mitarbeitershop_Hydro.IRepositories
{
    public interface ISubCategoryRepository
    {
        IQueryable<SubCategory> GetSubCategories();
        Task<SubCategory> GetSubCategoryByIdAsync(string id);
        Task AddSubCategoryAsync(SubCategory subCategory);
        Task UpdateSubCategoryAsync(SubCategory subSubCategory);
        Task DeleteSubCategoryAsync(string id);
    }
}
