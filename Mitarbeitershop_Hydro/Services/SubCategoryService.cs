using Microsoft.EntityFrameworkCore;
using Mitarbeitershop_Hydro.Helpers.IHelpersServices;
using Mitarbeitershop_Hydro.IRepositories;
using Mitarbeitershop_Hydro.IServices;
using Mitarbeitershop_Hydro.Models;
using Mitarbeitershop_Hydro.Repositories;
using Mitarbeitershop_Hydro.ViewModels;

namespace Mitarbeitershop_Hydro.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository, ICloudinaryService cloudinaryService)
        {
            _subCategoryRepository = subCategoryRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task AddSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel)
        {
            if (addSubCategoryViewModel == null) throw new ArgumentNullException("addSubCategoryViewModel");

            var imageUploadResult = await _cloudinaryService.AddPhotoAsync(addSubCategoryViewModel.ImageFile);

            var subCategory = new SubCategory
            {
                CategoryId = addSubCategoryViewModel.CategoryId,
                Name = addSubCategoryViewModel.Name,
                Image = imageUploadResult.Url.ToString(),
            };

            await _subCategoryRepository.AddSubCategoryAsync(subCategory);
        }

        public async Task DeleteSubCategoryAsync(string id) =>
            await _subCategoryRepository.DeleteSubCategoryAsync(id);

        public async Task<List<SubCategory>> GetSubCategoriesAsync() =>
            await _subCategoryRepository.GetSubCategories().ToListAsync();

        public async Task<SubCategory> GetSubCategoryByIdAsync(string id) =>
            await _subCategoryRepository.GetSubCategoryByIdAsync(id);

        public async Task UpdateSubCategoryAsync(SubCategory subCategory) =>
            await _subCategoryRepository.UpdateSubCategoryAsync(subCategory);
    }
}
