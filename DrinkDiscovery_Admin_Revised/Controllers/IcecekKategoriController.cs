using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class IcecekKategoriController : Controller
    {
        private IRepository repository;
        public IcecekKategoriController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KategoriListele()
        {
            var deger = repository.IcecekKategoriler.ToList();
            return View(deger);
        }

        // kategori crud işlemlerinde kaldık. aynısını ürünler için de yapacağız.

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }

        Context c = new Context();
        [HttpPost]
        public IActionResult KategoriEkle(IcecekKategoris yeni_kategori)
        {
            c.IcecekKategoriler.Add(yeni_kategori);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }

        //DBCC CHECKIDENT('your_table_name', RESEED, 2);
        public IActionResult KategoriSil(int id)
        {
            var ktg = c.IcecekKategoriler.Find(id);
            c.IcecekKategoriler.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("KategoriListele");
        }

        [HttpGet]
        public IActionResult KategoriDuzenle(int id)
        {
            var ktg = c.IcecekKategoriler.Find(id);
            return View("KategoriDuzenle", ktg);
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(IcecekKategoris k)
        {
            //Console.WriteLine($"Gönderilen id değeri: {k.icecek_kategori_id}");
            // İlgili kategoriyi veritabanında arayın
            var ktg = c.IcecekKategoriler.FirstOrDefault(i => i.icecek_kategori_id == k.icecek_kategori_id);
            if (ktg == null)
            {
                // Kategori bulunamadıysa loglama yapın
                //Console.WriteLine($"Kategori bulunamadı: id = {k.icecek_kategori_id}");
                return NotFound();
            }

            // Kategoriyi güncelleyin
            try
            {
                ktg.icecek_kategori_ad = k.icecek_kategori_ad;
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
