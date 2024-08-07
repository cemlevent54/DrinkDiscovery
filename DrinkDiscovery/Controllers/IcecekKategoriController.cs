using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;

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
            
            // kategoriId'ye göre filtreleme yap
            if (kategoriId != 0)
            {
                model.Icecekler = repository.Icecekler.Where(i => i.IcecekKategoriId == kategoriId);
            }
            return View(model);

        }
    }
}
