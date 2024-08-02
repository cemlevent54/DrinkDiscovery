using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class IcecekKategoriController : Controller
    {
        public IRepository repository;
        public IcecekKategoriController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KategoriListele()
        {
            var deger = repository.IcecekKategoriler.ToList();
            return View(deger);
        }

        // kategori crud işlemlerinde kaldık. aynısını ürünler için de yapacağız.
    }
}
