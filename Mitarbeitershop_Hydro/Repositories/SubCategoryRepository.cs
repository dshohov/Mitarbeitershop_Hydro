using Mitarbeitershop_Hydro.IRepositories;
using Mitarbeitershop_Hydro.Models;

namespace Mitarbeitershop_Hydro.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly IBaseRepository<SubCategory> _baseRepository;
        public SubCategoryRepository(IBaseRepository<SubCategory> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        
        public IQueryable<SubCategory> GetSubCategories() =>
            _baseRepository.QueryIternal();

        public async Task<SubCategory> GetSubCategoryByIdAsync(string id) =>
            await _baseRepository.GetByIdIternalAsync(id);

        public async Task AddSubCategoryAsync(SubCategory subCategory) =>
            await _baseRepository.AddIternalAsync(subCategory);

        public async Task UpdateSubCategoryAsync(SubCategory subSubCategory) =>
            await _baseRepository.UpdateIternalAsync(subSubCategory);
        
        public async Task DeleteSubCategoryAsync(string id) =>
            await _baseRepository.DeleteIternalAsync(id);

    }
}
