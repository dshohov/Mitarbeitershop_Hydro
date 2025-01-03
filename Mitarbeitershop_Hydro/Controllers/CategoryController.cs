using Microsoft.AspNetCore.Mvc;

namespace Mitarbeitershop_Hydro.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
