using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery.Controllers
{
    public class UrunKategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IRepository repository;

        public UrunKategoriController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Urunler(int kategoriId)
        {
            var model = new HomeViewModel(repository);
            // kategoriId'ye göre filtreleme yap
            if (kategoriId != 0)
            {
                model.Urunler = repository.Urunler.Where(i => i.UrunKategoriId == kategoriId);
            }
            return View(model);
        }
    }
}
