using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Mitarbeitershop_Hydro.Helpers.IHelpersServices;
using Mitarbeitershop_Hydro.IRepositories;
using Mitarbeitershop_Hydro.IServices;
using Mitarbeitershop_Hydro.Models;
using Mitarbeitershop_Hydro.ViewModels;

namespace Mitarbeitershop_Hydro.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICloudinaryService _cloudinaryService;

        public CategoryService(ICloudinaryService cloudinaryService, ICategoryRepository categoryRepository)
        {
            _cloudinaryService = cloudinaryService;
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(AddCategoryViewModel addCategoryViewModel)
        {
            if(addCategoryViewModel == null) throw new ArgumentNullException("category");

            var imageUploadResult = await _cloudinaryService.AddPhotoAsync(addCategoryViewModel.ImageFile);

            var category = new Category
            {
                Name = addCategoryViewModel.Name,
                Image = imageUploadResult.Url.ToString(),
            };

            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategories().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");

            await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
