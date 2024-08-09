using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery.Controllers
{
    public class TatliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IRepository repository;

        public TatliController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult GetImage(int id)
        {
            var tatli = repository.Tatlilar.FirstOrDefault(i => i.TatliId == id);
            if (tatli != null && tatli.TatliResim != null)
            {
                return File(tatli.TatliResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult TatliDetay(int id)
        {
            var selectedSweet = repository.Tatlilar
                                       .Include(i => i.TatliKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.TatliId == id);

            ViewBag.SelectedSweet = selectedSweet;
            ViewBag.SelectedSweetCategory = selectedSweet?.TatliKategori;

            var model = new HomeViewModel(repository);
            return View(model);
        }
    }
}
