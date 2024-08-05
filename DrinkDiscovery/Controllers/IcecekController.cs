using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
