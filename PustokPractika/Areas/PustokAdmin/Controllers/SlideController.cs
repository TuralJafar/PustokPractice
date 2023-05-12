using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokPractika.DAL;
using PustokPractika.Models;

namespace PustokPractika.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;

        public SlideController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _context.slides.ToListAsync();

            return View(slides);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {
            if (slide.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil hissesi bosh ola bilmez");
                return View();
            }

            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin tipi uygun deyil");
                return View();
            }
            if (slide.Photo.Length > 200 * 1024)
            {
                ModelState.AddModelError("Photo", "Gonderilen file-nin hecmi 200 kb-den boyuk olmamalidir");
                return View();
            }

            //  FileStream file = new FileStream(@"C:\Users\tural\Source\Repos\PustokPractice\PustokPractika\wwwroot\admin\images\" + slide.Photo.FileName, FileMode.Create);
            //  await slide.Photo.CopyToAsync(file);


            slide.Image = slide.Photo.FileName;

            await _context.slides.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }
            Slide slide = await _context.slides.FirstOrDefaultAsync(x => x.Id == id);
            if (slide == null) return NotFound();
            _context.slides.Remove(slide);
            await _context.SaveChangesAsync();
            //System.IO.File.Delete(slide.Photo.FileName);
            return RedirectToAction();

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Slide existed = await _context.slides.FirstOrDefaultAsync(c => c.Id == id);

            if (existed == null) return NotFound();

            return View(existed);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Slide slide)
        {
            if (id == null || id < 1) return BadRequest();

            Slide existed = await _context.slides.FirstOrDefaultAsync(c => c.Id == id);

            if (existed == null) return NotFound();


            if (existed.Title == slide.Title)

            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(existed);
            }

            bool result = _context.slides.Any(c => c.Title.Trim().ToLower() == slide.Title.Trim().ToLower() && c.Id != id);

            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda categoriya artiq movcuddur");
                return View(existed);
            }

            existed.Title = slide.Title;


            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

        }
    }
}