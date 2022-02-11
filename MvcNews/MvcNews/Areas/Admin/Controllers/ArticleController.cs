using Microsoft.AspNetCore.Mvc;

namespace MvcNews.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
