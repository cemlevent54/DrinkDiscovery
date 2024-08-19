using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery_Revised.Controllers
{
    public class UrunKategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IRepository repository { get; set; }
        public UrunKategoriController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Urunler(int kategoriId)
        {
            var model = new HomeViewModel(repository);
            //

            // kategoriId'ye göre filtreleme yap
            if (kategoriId != 0)
            {
                model.Urunler = repository.Urunler.Where(i => i.UrunKategoriId == kategoriId);
            }
            return View(model);

        }
    }
}
