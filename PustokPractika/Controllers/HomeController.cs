using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokPractika.DAL;
using PustokPractika.ViewModels;

namespace PustokPractika.Controllers
{
    //[Area("PustokAdmin")]
    public class HomeController : Controller
    {

        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                slides = await _context.slides.ToListAsync(),
            };
            return View(homeVM);
        }
    }
}
