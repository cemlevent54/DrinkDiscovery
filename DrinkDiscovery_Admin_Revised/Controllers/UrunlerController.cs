using Microsoft.AspNetCore.Mvc;
using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class UrunlerController : Controller
    {
        private IRepository repository;
        public UrunlerController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetImage(int id)
        {
            var urun = repository.Urunler.FirstOrDefault(i => i.urun_id == id);
            if (urun != null && urun.urun_resim != null)
            {
                return File(urun.urun_resim, "image/jpeg");
            }
            return NotFound();
        }
        
        public IActionResult UrunGoruntule()
        {
            var deger = repository.Urunler.Include(i => i.urun_kategori).ToList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            var kategoriler = repository.UrunKategoriler
                                        .Select(k => new SelectListItem
                                        {
                                            Text = k.urun_kategori_ad,
                                            Value = k.urun_kategori_id.ToString()
                                        }).ToList();
            ViewBag.dgr = new SelectList(kategoriler, "Value", "Text");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urunlers yeni_urun, IFormFile urun_resim)
        {
            if (urun_resim != null && urun_resim.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await urun_resim.CopyToAsync(memoryStream);
                    yeni_urun.urun_resim = memoryStream.ToArray();
                }
            }

            var kategori = repository.UrunKategoriler
                           .FirstOrDefault(i => i.urun_kategori_id == yeni_urun.urun_kategori.urun_kategori_id);

            if (kategori != null)
            {
                yeni_urun.urun_kategori = kategori;

                await repository.AddAsync(yeni_urun);
                await repository.SaveChangesAsync();

                return RedirectToAction("UrunGoruntule");
            }
            else
            {
                // Handle the error when the category is not found
                ModelState.AddModelError("", "Selected category does not exist.");
                return View(yeni_urun);
            }
        }

        public IActionResult UrunSil(int id)
        {
            var urun = repository.Urunler.FirstOrDefault(i => i.urun_id == id);
            if (urun != null)
            {
                repository.Delete(urun);
                repository.SaveChanges();
            }
            return RedirectToAction("UrunGoruntule");
        }

        [HttpGet]
        public IActionResult UrunDuzenle(int id)
        {
            var deger = repository.Urunler
                          .Include(i => i.urun_kategori)
                          .FirstOrDefault(i => i.urun_id == id);

            if (deger == null)
            {
                return NotFound();
            }

            // onceden secilmis icecek kategori id sini dropdownlistte gosteren kod. bu degiskeni viewbagde tutuyoruz
            var katid = deger.urun_kategori?.urun_kategori_id;

            List<SelectListItem> kategoriler = repository.UrunKategoriler
                                .Select(k => new SelectListItem
                                {
                                    Text = k.urun_kategori_ad,
                                    Value = k.urun_kategori_id.ToString()
                                }).ToList();

            ViewBag.dgr = kategoriler;
            ViewBag.selectedcategory = katid;

            return View("UrunDuzenle", deger);
        }

        [HttpPost]
        public async Task<IActionResult> UrunDuzenle(Urunlers model, IFormFile urun_resim)
        {
            if (repository.Urunler == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Icecekler repository is null.");
            }

            var icecek = await repository.Urunler.FirstOrDefaultAsync(x => x.urun_id == model.urun_id);
            if (icecek == null)
            {
                return NotFound();
            }

            // Update fields
            icecek.urun_ad = model.urun_ad;
            icecek.urun_icerik = model.urun_icerik;
            icecek.urun_malzemeler = model.urun_malzemeler;
            icecek.urun_puan = model.urun_puan;
            icecek.urun_fiyat = model.urun_fiyat;

            // model nesnesinde icecek_kategori var mi kontrol et

            if (model.urun_kategori != null)
            {

                var kategori = await repository.UrunKategoriler
                                        .FirstOrDefaultAsync(i => i.urun_kategori_id == model.urun_kategori.urun_kategori_id);
                if (kategori != null)
                {
                    // varsa nesne ozelliklerini guncelle
                    icecek.urun_kategori = kategori;
                    icecek.urun_kategori.urun_kategori_ad = kategori.urun_kategori_ad;
                    icecek.urun_kategori.urun_kategori_id = kategori.urun_kategori_id;
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Kategori not found.");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "icecek_kategori is null in the model.");
            }

            // file upload ve resim ekleme fonksiyonu
            if (urun_resim != null && urun_resim.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await urun_resim.CopyToAsync(ms);
                    icecek.urun_resim = ms.ToArray();
                }
            }

            // hatalar icin try catch blogu
            try
            {
                repository.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error saving changes: {ex.Message}");
            }

            return RedirectToAction("UrunGoruntule");
        }



    }
}
