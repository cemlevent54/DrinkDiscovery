using DrinkDiscovery_Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery_Admin.Controllers
{
    public class IcecekController : Controller
    {

        private readonly IRepository repo;
        
        public IcecekController(IRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            var icecekler = repo.repo_icecekler;
            return View(icecekler);
        }


        [HttpGet]
        public IActionResult IcecekEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IcecekEkle(Iceceklers icecek)
        {
            var icecekler = repo.repo_icecekler;
            if (ModelState.IsValid)
            {
                //icecekler.Ekle(icecek);
                return RedirectToAction("Index");
            }
            return View(icecek);
        }
        
        // burada hata veriyor. repo pattern e bak
        Context c = new Context();
        [HttpGet]
        public IActionResult IcecekGoruntule()
        {
            var veri = c.Icecekler;
            var veriler = veri.ToList();
            return View(veriler);
        }
    }
}
