using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Revised.Controllers
{
    public class TatliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IRepository repository { get; set; }

        public TatliController(IRepository repo)
        {
            repository = repo;
            ViewBag.IcecekKategoriler = repository.IcecekKategoriler;
            ViewBag.TatlilarKategoriler = repository.TatlilarKategoriler;
            ViewBag.UrunKategoriler = repository.UrunKategoriler;
            ViewBag.Urunler = repository.Urunler;
            ViewBag.Tatlilar = repository.Tatlilar;
            ViewBag.Icecekler = repository.Icecekler;
            ViewBag.HaftaninIcecekleri = repository.Icecekler.Where(i => i.HaftaninIcecegi == true).ToList();
        }

        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var tatli = repository.Tatlilar.FirstOrDefault(i => i.TatliId == id);
            if (tatli != null && tatli.TatliResim != null)
            {
                return File(tatli.TatliResim, "image/jpeg");
            }
            return NotFound();
        }

        public ViewResult TatliDetay(int id)
        {
            var selectedSweet = repository.Tatlilar
                                       .Include(i => i.TatliKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.TatliId == id);

            ViewBag.SelectedSweet = selectedSweet;
            ViewBag.selectedSweetCategory = selectedSweet?.TatliKategori;

            
            return View();
        }
    }
}
