using Microsoft.AspNetCore.Mvc;
using DrinkDiscovery_Admin.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrinkDiscovery_Admin.Controllers
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
        Context c = new Context();
        public IActionResult IcecekListele()
        {
            //var degerler = c.Icecekler.ToList();
            var degerler = repository.Icecekler.ToList();
            
            return View(degerler);
        }

        [HttpGet]
        public IActionResult IcecekEkle()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IcecekEkle(Iceceklers icecekler, IFormFile icecek_resmi)
        {
            if (ModelState.IsValid)
            {
                if (icecek_resmi != null && icecek_resmi.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await icecek_resmi.CopyToAsync(memoryStream);
                        icecekler.icecek_resim = memoryStream.ToArray();
                    }
                }

                repository.Add(icecekler);
                await repository.SaveChangesAsync();

            }

            return RedirectToAction("IcecekListele");
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

        

        [HttpGet]
        public IActionResult IcecekDuzenle(int id)
        {
            var deger = repository.Icecekler.FirstOrDefault(i => i.icecek_id == id);
            return View(deger);
        }

        [HttpPost]
        public async Task<IActionResult> IcecekDuzenle(Iceceklers model, IFormFile icecek_resmi)
        {
            if (ModelState.IsValid)
            {
                var icecek = repository.Icecekler.FirstOrDefault(x => x.icecek_id == model.icecek_id);

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

                // Handle file upload
                if (icecek_resmi != null && icecek_resmi.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await icecek_resmi.CopyToAsync(ms);
                        icecek.icecek_resim = ms.ToArray();
                    }
                }

                repository.Update(icecek);
                await repository.SaveChangesAsync();

                
            }

            return RedirectToAction("IcecekListele");
        }




    }
}
