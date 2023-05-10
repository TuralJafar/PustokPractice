using Microsoft.AspNetCore.Mvc;

namespace PustokPractika.Controllers
{
    [Area("PustokAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
