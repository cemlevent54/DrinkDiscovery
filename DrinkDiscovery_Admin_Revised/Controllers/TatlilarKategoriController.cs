using Microsoft.AspNetCore.Mvc;
using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TatlilarKategoriController : Controller
    {
        private IRepository repository;
        public TatlilarKategoriController(IRepository _repository)
        {
            repository = _repository;
        }
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult KategoriListele()
        {
            var degerler = repository.TatlilarKategoriler;
            return View(degerler);
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(TatlilarKategoris yeni_kategori)
        {
            c.TatlilarKategoriler.Add(yeni_kategori);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }

        public IActionResult KategoriSil(int id)
        {
            var ktg = c.TatlilarKategoriler.Find(id);
            c.TatlilarKategoriler.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");

        }

        [HttpGet]
        public IActionResult KategoriDuzenle(int id)
        {
            var ktg = c.TatlilarKategoriler.Find(id);
            return View("KategoriDuzenle", ktg);
        }
        [HttpPost]
        public IActionResult KategoriDuzenle(TatlilarKategoris k)
        {
            //Console.WriteLine($"Gönderilen id değeri: {k.icecek_kategori_id}");
            // İlgili kategoriyi veritabanında arayın
            var ktg = c.TatlilarKategoriler.FirstOrDefault(i => i.tatli_kategori_id == k.tatli_kategori_id);
            if (ktg == null)
            {
                // Kategori bulunamadıysa loglama yapın
                //Console.WriteLine($"Kategori bulunamadı: id = {k.icecek_kategori_id}");
                return NotFound();
            }

            // Kategoriyi güncelleyin
            try
            {
                ktg.tatli_kategori_ad = k.tatli_kategori_ad;
                c.SaveChanges();
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapın
                //Console.WriteLine("Veritabanı güncelleme hatası: " + ex.Message);
                // Hata durumunda uygun bir hata sayfasına yönlendirebilirsiniz
                return StatusCode(500, "Veritabanı güncelleme hatası.");
            }

            // Başarıyla güncellendikten sonra listeleme sayfasına yönlendirin
            return RedirectToAction("KategoriListele");
        }
    }
}
