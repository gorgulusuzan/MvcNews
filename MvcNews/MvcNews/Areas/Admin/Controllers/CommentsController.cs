using Microsoft.AspNetCore.Mvc;

namespace MvcNews.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
