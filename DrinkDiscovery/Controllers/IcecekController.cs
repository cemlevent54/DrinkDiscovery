using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace DrinkDiscovery.Controllers
{
    public class IcecekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IRepository repository;
        public IcecekController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult GetImage(int id)
        {
            var icecek = repository.Icecekler.FirstOrDefault(i => i.IcecekId == id);
            if (icecek != null && icecek.IcecekResim != null)
            {
                return File(icecek.IcecekResim, "image/jpeg");
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

            var model = new HomeViewModel(repository);
            //{
            //    Icecekler = repository.Icecekler,
            //    IcecekKategoriler = repository.IcecekKategoriler,
            //    TatlilarKategoriler = repository.TatlilarKategoriler,
            //    UrunKategoriler = repository.UrunKategoriler,
            //};

            return View(model);
        }
    }
}
