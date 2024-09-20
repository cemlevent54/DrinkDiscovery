using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrinkDiscovery_Admin_Revised.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        private IRepository repository;
        private UserManager<DrinkDiscovery_Admin_Revised_User> userManager;
        private RoleManager<IdentityRole> roleManager;
        public UserController(IRepository _repository, UserManager<DrinkDiscovery_Admin_Revised_User> _userManager,RoleManager<IdentityRole> _roleManager)
        {
            repository = _repository;
            userManager= _userManager;
            roleManager = _roleManager;
        }

        public IActionResult ListUsers()
        {
            var deger = repository.Users.
                ToList();
            // kullanıcı rollerini getir
            var roles = roleManager.Roles.ToList();
            ViewBag.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();



            return View(deger);
        }

        public IActionResult GetImage(string id)
        {
            var photo = repository.Users.FirstOrDefault(t => t.Id == id);
            if (photo != null && photo.kullanici_fotograf != null)
            {
                return File(photo.kullanici_fotograf, "image/jpeg");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult UpdateUser(string id)
        {
            var user = repository.Users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View("UpdateUser", user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string selectedRole,DrinkDiscovery_Admin_Revised_User user)
        {
            var UsersRepository = repository.Users;
            if(UsersRepository == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Kullanıcılar bulunamadı.");
            }

            var userToUpdate = await repository.Users.FirstOrDefaultAsync(t => t.Id == user.Id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            userToUpdate.kullanici_ad = user.kullanici_ad;
            userToUpdate.kullanici_soyad = user.kullanici_soyad;
            userToUpdate.kullanici_mail = user.kullanici_mail;
            userToUpdate.kullanici_telefon = user.kullanici_telefon;
            userToUpdate.kullanici_username = user.kullanici_username;
            userToUpdate.kullanici_sifre = user.kullanici_sifre;
            //userToUpdate.kullanici_fotograf = user.kullanici_fotograf;
            //userToUpdate.kullanici_fotograf_file = user.kullanici_fotograf_file;
            var currentroles = await userManager.GetRolesAsync(userToUpdate);
            await userManager.RemoveFromRolesAsync(userToUpdate, currentroles);
            
            await userManager.AddToRoleAsync(userToUpdate,selectedRole );

            try
            {
                repository.UpdateUser(userToUpdate);
                repository.SaveChangesUser();
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return RedirectToAction("ListUsers");

        }

        

        public IActionResult DeleteUser(string id)
        {
            var user = repository.Users.FirstOrDefault(t => t.Id == id);
            var beverageComments = repository.IcecekYorumlars.Where(t => t.yorum_kullanici_id == id).ToList();
            var sweetComments = repository.TatlilarYorumlars.Where(t => t.yorum_kullanici_id == id).ToList();
            var productComments = repository.UrunlerYorumlars.Where(t => t.yorum_kullanici_id == id).ToList();
            var beverageCommentActions = repository.UserBeverageCommentActions.Where(t => t.user_id == id).ToList();
            var sweetCommentActions = repository.UserSweetCommentActions.Where(t => t.user_id == id).ToList();
            var productCommentActions = repository.UserProductCommentActions.Where(t => t.user_id == id).ToList();
            

            if (user != null)
            {
                // İlgili kullanıcının yorumlarını ve aksiyonlarını sil
                // Yorum ve aksiyonları tek tek sil
                foreach (var comment in beverageComments)
                {
                    repository.Delete(comment);
                }

                foreach (var comment in sweetComments)
                {
                    repository.Delete(comment);
                }

                foreach (var comment in productComments)
                {
                    repository.Delete(comment);
                }

                foreach (var action in beverageCommentActions)
                {
                    repository.Delete(action);
                }

                foreach (var action in sweetCommentActions)
                {
                    repository.Delete(action);
                }

                foreach (var action in productCommentActions)
                {
                    repository.Delete(action);
                }

                repository.DeleteUser(user);
                return RedirectToAction("ListUsers");
            }
            return NotFound();
        }

        public IActionResult Search(string search)
        {
            // İçcek adına göre arama
            var users = repository.Users
                .Where(i => i.kullanici_username.Contains(search) || string.IsNullOrEmpty(search))
                .ToList();

            return View("ListUsers", users);
        }

        
    }
}
