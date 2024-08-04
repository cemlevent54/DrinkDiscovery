using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class TatlilarController : Controller
    {
        private readonly IRepository repository;

        public TatlilarController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImage(int id)
        {
            var tatli = repository.Tatlilar.FirstOrDefault(t => t.tatli_id == id);
            if (tatli != null && tatli.tatli_resim != null)
            {
                return File(tatli.tatli_resim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult TatliListele()
        {
            var tatlilar = repository.Tatlilar
                                     .Include(t => t.tatli_kategori)
                                     .ToList();
            return View(tatlilar);
        }

        [HttpGet]
        public IActionResult TatliEkle()
        {
            var kategoriler = repository.TatlilarKategoriler
                                        .Select(k => new SelectListItem
                                        {
                                            Text = k.tatli_kategori_ad,
                                            Value = k.tatli_kategori_id.ToString()
                                        }).ToList();
            ViewBag.dgr = new SelectList(kategoriler, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TatliEkle(Tatlilars yeni_tatli, IFormFile tatli_resmi)
        {
            if (tatli_resmi != null && tatli_resmi.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await tatli_resmi.CopyToAsync(memoryStream);
                    yeni_tatli.tatli_resim = memoryStream.ToArray();
                }
            }

            var kategori = repository.TatlilarKategoriler
                                     .FirstOrDefault(k => k.tatli_kategori_id == yeni_tatli.tatli_kategori.tatli_kategori_id);

            if (kategori != null)
            {
                yeni_tatli.tatli_kategori = kategori;

                await repository.AddAsync(yeni_tatli);
                await repository.SaveChangesAsync();

                return RedirectToAction("TatliListele");
            }

            else ModelState.AddModelError("", "Selected category does not exist.");
            return View(yeni_tatli);
        }

        public IActionResult TatliSil(int id)
        {
            var tatli = repository.Tatlilar.FirstOrDefault(t => t.tatli_id == id);
            if (tatli != null)
            {
                repository.Delete(tatli);
                repository.SaveChanges();
                return RedirectToAction("TatliListele");
            }

            else ModelState.AddModelError("", "Selected dessert does not exist.");
            return RedirectToAction("TatliListele");
        }

        [HttpGet]
        public IActionResult TatliDuzenle(int id)
        {
            var tatli = repository.Tatlilar
                          .Include(t => t.tatli_kategori)
                          .FirstOrDefault(t => t.tatli_id == id);

            if (tatli == null)
            {
                return NotFound();
            }
            var katid = tatli.tatli_kategori?.tatli_kategori_id;
            var kategoriler = repository.TatlilarKategoriler
                                        .Select(k => new SelectListItem
                                        {
                                            Text = k.tatli_kategori_ad,
                                            Value = k.tatli_kategori_id.ToString()
                                        }).ToList();

            ViewBag.dgr = kategoriler;
            ViewBag.selectedcategory = katid;
            return View("TatliDuzenle", tatli);
        }
        [HttpPost]
        public async Task<IActionResult> TatliDuzenle(Tatlilars model, IFormFile tatli_resmi)
        {
            if (repository.Tatlilar == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tatlilar repository is null.");
            }
            var tatli = await repository.Tatlilar.FirstOrDefaultAsync(x => x.tatli_id == model.tatli_id);
            if (tatli == null)
            {
                return NotFound();
            }

            // Update fields
            tatli.tatli_ad = model.tatli_ad;
            tatli.tatli_aciklama = model.tatli_aciklama;
            tatli.tatli_malzemeler = model.tatli_malzemeler;
            tatli.tatli_yapilis = model.tatli_yapilis;
            tatli.tatli_fiyat = model.tatli_fiyat;
            tatli.tatli_puan = model.tatli_puan;
            tatli.tatli_id = model.tatli_id;


            // model nesnesinde icecek_kategori var mi kontrol et

            if (model.tatli_kategori != null)
            {

                var kategori = await repository.TatlilarKategoriler
                                        .FirstOrDefaultAsync(i => i.tatli_kategori_id == model.tatli_kategori.tatli_kategori_id);
                if (kategori != null)
                {
                    // varsa nesne ozelliklerini guncelle
                    tatli.tatli_kategori = kategori;
                    tatli.tatli_kategori.tatli_kategori_ad = kategori.tatli_kategori_ad;
                    tatli.tatli_kategori.tatli_kategori_id = kategori.tatli_kategori_id;
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Kategori not found.");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "tatli_kategori is null in the model.");
            }

            // file upload ve resim ekleme fonksiyonu
            if (tatli_resmi != null && tatli_resmi.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await tatli_resmi.CopyToAsync(ms);
                    tatli.tatli_resim = ms.ToArray();
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

            return RedirectToAction("TatliListele");
        }

    }
}
