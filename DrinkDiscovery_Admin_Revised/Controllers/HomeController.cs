using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepository _repository)
        {
            _logger = logger;
            repository=_repository;
        }
        public IRepository repository;
        public IActionResult Index()
        {
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

        public PartialViewResult Search(string search)
        {
            // Ýçcek adýna göre arama
            var icecekler = repository.Icecekler
                .Include(i => i.icecek_kategori) // Include the related category if needed
                .Where(i => i.icecek_ad.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            var tatlilar = repository.Tatlilar
                .Include(i => i.tatli_kategori) // Include the related category if needed
                .Where(i => i.tatli_ad.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            var urunler = repository.Urunler
                .Include(i => i.urun_kategori) // Include the related category if needed
                .Where(i => i.urun_ad.StartsWith(search) || string.IsNullOrEmpty(search))
                .ToList();
            // ortak arama için bir model oluþtur
            ViewBag.Icecekler = icecekler;
            ViewBag.Tatlilar = tatlilar;
            ViewBag.Urunler = urunler;



            return PartialView("SearchResultPartial");
        }

        

        
    }
}
