using Microsoft.AspNetCore.Mvc;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
