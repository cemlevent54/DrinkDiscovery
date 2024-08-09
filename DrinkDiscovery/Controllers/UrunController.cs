using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public IActionResult UrunDetay(int id)
        {
            var selectedProduct = repository.Urunler
                                       .Include(i => i.UrunKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.UrunId == id);

            ViewBag.selectedProduct = selectedProduct;
            ViewBag.selectedProductCategory = selectedProduct?.UrunKategori;

            var model = new HomeViewModel(repository);
            //
            

            return View(model);
        }
    }
}
