using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace DrinkDiscovery_Revised.Controllers
{
    public class IcecekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IRepository repository { get; set; }
        public IcecekController(IRepository repo)
        {
            repository = repo;
            ViewBag.IcecekKategoriler = repository.IcecekKategoriler;
            ViewBag.TatlilarKategoriler = repository.TatlilarKategoriler;
            ViewBag.UrunKategoriler = repository.UrunKategoriler;
            ViewBag.Urunler = repository.Urunler;
            ViewBag.Tatlilar = repository.Tatlilar;
            ViewBag.Icecekler = repository.Icecekler;
            ViewBag.HaftaninIcecekleri = repository.Icecekler.Where(i => i.HaftaninIcecegi == true).ToList();

        }
        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var urun = repository.Icecekler.FirstOrDefault(i => i.IcecekId == id);
            if (urun != null && urun.IcecekResim != null)
            {
                return File(urun.IcecekResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult IcecekDetay(int id)
        {
            var selectedBeverage = repository.Icecekler
                                       .Include(i => i.IcecekKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.IcecekId == id);

            ViewBag.SelectedBeverage = selectedBeverage;
            ViewBag.SelectedBeverageCategory = selectedBeverage?.IcecekKategori;

            //var model = new HomeViewModel(repository);
            //
            //{
            //    Icecekler = repository.Icecekler,
            //    IcecekKategoriler = repository.IcecekKategoriler,
            //    TatlilarKategoriler = repository.TatlilarKategoriler,
            //    UrunKategoriler = repository.UrunKategoriler,
            //};

            //return View(model);
            return View();
        }

        public PartialViewResult IcecekKategorilerPartial()
        {
            return PartialView(repository.IcecekKategoriler);
        }
    }
}
