using Microsoft.AspNetCore.Http;

namespace Mitarbeitershop_Hydro.ViewModels
{
    public class AddCategoryViewModel
    {
        public string Name { get; set; }
        public IFormFile ImageFile {  get; set; }  
    }
}
