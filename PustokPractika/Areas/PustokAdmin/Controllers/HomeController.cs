using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokPractika.DAL;
using PustokPractika.Models;

namespace PustokPractika.Areas.PustokAdmin.Controllers
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
