using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IRepository repository;
        public UrunController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            if (urun != null && urun.UrunResim != null)
            {
                return File(urun.UrunResim, "image/jpeg");
            }
            return NotFound();
        }
    }
}
