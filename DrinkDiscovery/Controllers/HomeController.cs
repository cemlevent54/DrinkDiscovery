using DrinkDiscovery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Search()
        {

            return View();
        }

        public IActionResult Login()
        {
            var viewModel = new HomeViewModel(repository);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            var viewModel = new HomeViewModel(repository);
            return View(viewModel);
        }

        // burada kaldýk. bu fonksiyonu implement et
        [HttpPost]
        public async Task<IActionResult> SignUp (Kullanicilar yeni_kullanici,IFormFile kullanici_resmi)
        {
            HomeViewModel hvminstance = new HomeViewModel(repository);
            try
            {
                
                if (kullanici_resmi != null && kullanici_resmi.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await kullanici_resmi.CopyToAsync(memoryStream);
                        yeni_kullanici.KullaniciFotograf = memoryStream.ToArray();
                    }
                }

                await repository.AddAsync(yeni_kullanici);
                await repository.SaveChangesAsync();
                return View("SignUp", hvminstance);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(hvminstance);
            }
        }
        
    }
}
