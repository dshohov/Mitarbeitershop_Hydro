using Mitarbeitershop_Hydro.Models;

namespace Mitarbeitershop_Hydro.IRepositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Task<Category> GetCategoryByIdAsync(string id); 
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(string id);
    }
}
