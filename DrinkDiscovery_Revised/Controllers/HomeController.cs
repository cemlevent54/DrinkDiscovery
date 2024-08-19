using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
