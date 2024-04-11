using Microsoft.AspNetCore.Mvc;

namespace HotelsManagment.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
