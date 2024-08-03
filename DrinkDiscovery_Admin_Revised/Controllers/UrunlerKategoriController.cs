using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class UrunlerKategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private IRepository repository;
        public UrunlerKategoriController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult KategoriListele()
        {
            var deger = repository.UrunKategoriler.ToList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
        
        Context c = new Context();
        [HttpPost]
        public IActionResult KategoriEkle(UrunKategoris yeni_kategori)
        {
            c.UrunKategoriler.Add(yeni_kategori);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }

        public IActionResult KategoriSil(int id)
        {
            var ktg = c.UrunKategoriler.Find(id);
            c.UrunKategoriler.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }

        [HttpGet]
        public IActionResult KategoriDuzenle(int id)
        {
            var ktg = c.UrunKategoriler.Find(id);
            return View("KategoriDuzenle", ktg);
        }
        [HttpPost]
        public IActionResult KategoriDuzenle(UrunKategoris k)
        {
            var ktg = c.UrunKategoriler.Find(k.urun_kategori_id);
            ktg.urun_kategori_ad = k.urun_kategori_ad;
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }
    }
}
