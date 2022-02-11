using Microsoft.AspNetCore.Mvc;

namespace MvcNews.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
