using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Hydro;
using Hydro.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mitarbeitershop_Hydro.IServices;
using Mitarbeitershop_Hydro.ViewModels;

namespace Mitarbeitershop_Hydro.Views.Category.Components
{
    public class AddCategory(ICategoryService _categoryService) : HydroComponent
    {
        public string Name { get; set; }
        [Transient]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string ImagetId { get; set; }

        public async Task Save()
        {
            if (!Validate())
            {
                return;
            }

            var tempFilePath = GetTempFileLocation(ImagetId);

            try
            {
                
                using var stream = File.OpenRead(tempFilePath);
                var formFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(tempFilePath))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/octet-stream"
                };

                var addCategoryViewModel = new AddCategoryViewModel() { Name = Name, ImageFile = formFile };
                await _categoryService.AddCategoryAsync(addCategoryViewModel);
            }
            finally
            {
                
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
                Location(Url.Action("Index","Category"));
            }
            

        }

        public override async Task BindAsync(PropertyPath property, object value)
        {
            if (property.Name == nameof(ImageFile))
            {
                // assign the temp file name to the DocumentId
                ImagetId = await GetStoredTempFileId((IFormFile)value);
            }
        }

        private static async Task<string> GetStoredTempFileId(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            var tempFileName = Guid.NewGuid().ToString("N");
            var tempFilePath = GetTempFileLocation(tempFileName);

            await using var readStream = file.OpenReadStream();
            await using var writeStream = File.OpenWrite(tempFilePath);
            await readStream.CopyToAsync(writeStream);

            return tempFileName;
        }

        private static string GetTempFileLocation(string fileName) =>
            Path.Combine(Path.GetTempPath(), fileName);
    }
}
