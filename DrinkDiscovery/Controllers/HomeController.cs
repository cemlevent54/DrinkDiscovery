using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrinkDiscovery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IRepository repository;

        public HomeController(ILogger<HomeController> logger, IRepository _repository)
        {
            _logger = logger;
            repository= _repository;
        }

        public IActionResult Index()
        {
            // ViewModel'i olustur
            var viewModel = new HomeViewModel(repository);
            //{
            //    // ilgili verileri repository'den al ve ViewModel'e ekle
            //    IcecekKategoriler = repository.GetIcecekKategoriler(),
            //    TatlilarKategoriler = repository.GetTatlilarKategoriler(),
            //    UrunKategoriler = repository.GetUrunKategoriler(),
            //    HaftaninIcecekleri = repository.GetHaftaninIcecekleri(),
            //    Urunler = repository.GetUrunler()
            //};

            var v = viewModel;
            // View'e ViewModel'i geçir
            return View(viewModel);
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

        
    }
}
