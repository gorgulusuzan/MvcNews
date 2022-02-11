using Microsoft.AspNetCore.Mvc;

namespace MvcNews.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
