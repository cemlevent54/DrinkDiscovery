using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery_Revised.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IRepository repository;
        public OrderController(IRepository _repository)
        {
            repository = _repository;
        }

        
    }
}
