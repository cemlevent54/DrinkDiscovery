using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery.Controllers
{
    public class IcecekKategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IRepository repository { get; set; }
        public IcecekKategoriController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Icecekler(int kategoriId)
        {
            var model = new HomeViewModel(repository);
            //
            
            // kategoriId'ye göre filtreleme yap
            if (kategoriId != 0)
            {
                model.Icecekler = repository.Icecekler.Where(i => i.IcecekKategoriId == kategoriId);
            }
            return View(model);

        }

        public IActionResult Search(string search)
        {
            //// If search string is empty or null, return all beverages
            //var icecekler = string.IsNullOrEmpty(search)
            //    ? repository.Icecekler.ToList()
            //    : repository.Icecekler
            //        .Where(i => i.IcecekAd.Contains(search))
            //        .ToList();

            //return View("Icecekler", icecekler); // Replace "YourViewName" with the actual view name

            return View();
        }
    }
}
