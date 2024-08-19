using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery_Revised.Controllers
{
    public class TatliKategoriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IRepository repository { get; set; }
        public TatliKategoriController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Tatlilar(int kategoriId)
        {
            var model = new HomeViewModel(repository);

            if (kategoriId != 0)
            {
                model.Tatlilar = repository.Tatlilar.Where(i => i.TatliKategoriId == kategoriId);
            }
            return View(model);
        }
    }
}
