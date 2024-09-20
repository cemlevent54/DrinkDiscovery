using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> manager;
        public IRepository repository;
        public RoleController(RoleManager<IdentityRole> _manager, IRepository _repository)
        {
            manager = _manager;
            repository = _repository;
        }


        public IActionResult Index()
        {
            var roles = manager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(IdentityRole role)
        {
            // check if the role already exists
            if(!manager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                manager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");

        }

        
    }
}
