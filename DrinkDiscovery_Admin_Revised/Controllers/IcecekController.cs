using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class IcecekController : Controller
    {
        private IRepository repository;
        public IcecekController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetImage(int id)
        {
            var icecek = repository.Icecekler.FirstOrDefault(i => i.icecek_id == id);
            if (icecek != null && icecek.icecek_resim != null)
            {
                return File(icecek.icecek_resim, "image/jpeg");
            }
            return NotFound();
        }
        public IActionResult IcecekListele()
        {
            var degerler = repository.Icecekler
                                     .Include(i => i.icecek_kategori)
                                     .ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult IcecekEkle()
        {
            // icecek kategorileri viewbage repository kullanarak at
            var kategoriler = repository.IcecekKategoriler
                                        .Select(k => new SelectListItem
                                        {
                                            Text = k.icecek_kategori_ad,
                                            Value = k.icecek_kategori_id.ToString()
                                        }).ToList();
            ViewBag.dgr = new SelectList(kategoriler, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IcecekEkle(Iceceklers yeni_icecek, IFormFile icecek_resmi)
        {

            if (icecek_resmi != null && icecek_resmi.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await icecek_resmi.CopyToAsync(memoryStream);
                    yeni_icecek.icecek_resim = memoryStream.ToArray();
                }
            }

            var kategori = repository.IcecekKategoriler
                                     .FirstOrDefault(i => i.icecek_kategori_id == yeni_icecek.icecek_kategori.icecek_kategori_id);

            if (kategori != null)
            {
                yeni_icecek.icecek_kategori = kategori;

                await repository.AddAsync(yeni_icecek);
                await repository.SaveChangesAsync();

                return RedirectToAction("IcecekListele");
            }
            else
            {
                // Handle the error when the category is not found
                ModelState.AddModelError("", "Selected category does not exist.");
                return View(yeni_icecek);
            }

        }
        public IActionResult IcecekSil(int id)
        {
            var icecek = repository.Icecekler.FirstOrDefault(i => i.icecek_id == id);
            if (icecek != null)
            {
                repository.Delete(icecek);
                repository.SaveChanges();
            }
            return RedirectToAction("IcecekListele");
        }

        // icecek duzenleme 
        [HttpGet]
        public IActionResult IcecekDuzenle(int id)
        {
            var deger = repository.Icecekler.FirstOrDefault(i => i.icecek_id == id);
            //deger.icecek_kategori.icecek_kategori_id;
            if (deger == null)
            {
                return NotFound();
            }

            var kategoriler = repository.IcecekKategoriler
                                .Select(k => new SelectListItem
                                {
                                    Text = k.icecek_kategori_ad,
                                    Value = k.icecek_kategori_id.ToString()
                                }).ToList();
            ViewBag.dgr = kategoriler;
            return View(deger);
        }

        [HttpPost]
        public async Task<IActionResult> IcecekDuzenle(Iceceklers model, IFormFile icecek_resmi)
        {
            if (ModelState.IsValid)
            {
                var icecek = await repository.Icecekler.FirstOrDefaultAsync(x => x.icecek_id == model.icecek_id);
                if (icecek == null)
                {
                    return NotFound();
                }

                // Update fields
                icecek.icecek_ad = model.icecek_ad;
                icecek.icecek_icerik = model.icecek_icerik;
                icecek.icecek_malzemeler = model.icecek_malzemeler;
                icecek.icecek_puan = model.icecek_puan;
                icecek.icecek_fiyat = model.icecek_fiyat;

                // Update category
                var kategori = repository.IcecekKategoriler
                                     .FirstOrDefault(i => i.icecek_kategori_id == icecek.icecek_kategori.icecek_kategori_id);
                icecek.icecek_kategori = kategori;

                // Handle file upload
                if (icecek_resmi != null && icecek_resmi.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await icecek_resmi.CopyToAsync(ms);
                        icecek.icecek_resim = ms.ToArray();
                    }
                }

                //repository.Update(icecek);
                await repository.SaveChangesAsync();

                
            }
            return RedirectToAction("IcecekListele");

        }
    }
}
