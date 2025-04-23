using Microsoft.AspNetCore.Mvc;

namespace IntroASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List", "MenuChoice");
        }
    }
}
