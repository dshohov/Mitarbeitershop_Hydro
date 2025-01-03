using Hydro;
using Mitarbeitershop_Hydro;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using Mitarbeitershop_Hydro.IServices;

namespace Mitarbeitershop_Hydro.Views.Category.Components
{
    public class ListCategory(ICategoryService _categoryService) : HydroComponent
    {
        public List<Models.Category> Categories = new List<Models.Category>();
        public override async Task MountAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();  
        }

        public async Task DeleteCategory(string idCategory)
        {
            await _categoryService.DeleteCategoryAsync(idCategory);
            Location(Url.Action("Index", "Category"));
        }

    }
}
