using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DrinkDiscovery_Revised.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DrinkDiscoveryAdminContext context, IRepository _repository)
        {
            _logger = logger;
            _context=context;
            repository=_repository;
        }

        public IRepository repository { get; set; }

        public DrinkDiscoveryAdminContext _context;
        public IActionResult Index()
        {
            // IcecekKategoriler listesini ViewData'ya ekleyin
            ViewBag.Icecekler = _context.Iceceklers.ToList();
            ViewBag.IcecekKategoriler = _context.IcecekKategorilers.ToList();
            var v = ViewBag.IcecekKategoriler;
            ViewBag.TatlilarKategoriler = _context.TatlilarKategorilers.ToList();
            ViewBag.UrunKategoriler = _context.UrunKategorilers.ToList();
            ViewBag.Urunler = _context.Urunlers.ToList();
            ViewBag.Tatlilar = _context.Tatlilars.ToList();
            ViewBag.Icecekler = _context.Iceceklers.ToList();
            ViewBag.HaftaninIcecekleri = _context.Iceceklers.Where(i => i.HaftaninIcecegi == true).ToList();
            // View'e ana modelinizi geçirin
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public PartialViewResult IcecekKategorileriGetirPartial()
        {
            return PartialView(repository.IcecekKategoriler.ToList());
        }

        public PartialViewResult TatliKategorileriGetirPartial()
        {
            return PartialView(repository.TatlilarKategoriler.ToList());
        }

        public PartialViewResult UrunKategorileriGetirPartial()
        {
            return PartialView(repository.UrunKategoriler.ToList());
        }

        public PartialViewResult Search(string search)
        {
            // Ýçcek adýna göre arama
            var icecekler = repository.Icecekler
                .Include(i => i.IcecekKategori) // Include the related category if needed
                .Where(i => i.IcecekAd.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            var tatlilar = repository.Tatlilar
                .Include(i => i.TatliKategori) // Include the related category if needed
                .Where(i => i.TatliAd.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            var urunler = repository.Urunler
                .Include(i => i.UrunKategori) // Include the related category if needed
                .Where(i => i.UrunAd.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            // ortak arama için bir model oluþtur
            ViewBag.Icecekler = icecekler;
            ViewBag.Tatlilar = tatlilar;
            ViewBag.Urunler = urunler;

            return PartialView("SearchResultPartial");
        }

        
        public ViewResult IndexIcecekler(int? kategoriId)
        {
            List<Icecekler> drinksInCategory;

            // If no category is selected, display all drinks
            if (kategoriId.HasValue && kategoriId.Value > 0)
            {
                drinksInCategory = _context.Iceceklers
                    .Where(i => i.IcecekKategoriId == kategoriId.Value)
                    .ToList();
            }
            else
            {
                // No category selected, display all drinks
                drinksInCategory = _context.Iceceklers.ToList();
            }

            var categories = repository.IcecekKategoriler.ToList();

            ViewBag.Icecekler = drinksInCategory;
            ViewBag.SelectedCategoryId = kategoriId ?? 0;  // If no category, set to 0
            return View("IndexIcecekler", categories);
        }

        public ViewResult IndexTatlilar(int? kategoriId)
        {
            List<Tatlilar> sweetsInCategory;

            // If no category is selected, display all drinks
            if (kategoriId.HasValue && kategoriId.Value > 0)
            {
                sweetsInCategory = _context.Tatlilars
                    .Where(i => i.TatliKategoriId == kategoriId.Value)
                    .ToList();
            }
            else
            {
                // No category selected, display all drinks
                sweetsInCategory = _context.Tatlilars.ToList();
            }

            var categories = repository.TatlilarKategoriler.ToList();

            ViewBag.Tatlilar = sweetsInCategory;
            ViewBag.SelectedSweetCategoryId = kategoriId ?? 0;  // If no category, set to 0
            return View("IndexTatlilar", categories);
        }

        public ViewResult IndexUrunler(int? kategoriId)
        {

           List<Urunler> productsInCategory;

            // If no category is selected, display all drinks
            if (kategoriId.HasValue && kategoriId.Value > 0)
            {
                productsInCategory = _context.Urunlers
                    .Where(i => i.UrunKategoriId == kategoriId.Value)
                    .ToList();
            }
            else
            {
                // No category selected, display all drinks
                productsInCategory = _context.Urunlers.ToList();
            }

            var categories = repository.UrunKategoriler.ToList();

            ViewBag.Urunler = productsInCategory;
            ViewBag.SelectedProductCategoryId = kategoriId ?? 0;  // If no category, set to 0
            return View("IndexUrunler", categories);
        } 

        
        
    }
}
