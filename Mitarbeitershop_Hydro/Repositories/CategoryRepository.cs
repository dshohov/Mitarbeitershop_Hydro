using Microsoft.EntityFrameworkCore;
using Mitarbeitershop_Hydro.Data;
using Mitarbeitershop_Hydro.IRepositories;
using Mitarbeitershop_Hydro.Models;

namespace Mitarbeitershop_Hydro.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IBaseRepository<Category> _baseRepository;
        public CategoryRepository(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<Category> GetCategories() => 
            _baseRepository.QueryIternal();

        public async Task<Category> GetCategoryByIdAsync(string id) =>
            await _baseRepository.GetByIdIternalAsync(id);


        public async Task AddCategoryAsync(Category category) =>
            await _baseRepository.AddIternalAsync(category);

        public async Task UpdateCategoryAsync(Category category) =>
            await _baseRepository.UpdateIternalAsync(category);

        public async Task DeleteCategoryAsync(string id) =>
            await _baseRepository.DeleteIternalAsync(id);
    }
}

