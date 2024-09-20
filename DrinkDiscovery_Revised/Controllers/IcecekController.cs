using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using DrinkDiscovery_Revised.Helpers;
using DrinkDiscovery_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using NuGet.Versioning;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;

namespace DrinkDiscovery_Revised.Controllers
{
    public class IcecekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public DrinkDiscoveryAdminContext context { get; set; }
        public IRepository repository { get; set; }
        public UserService userService;

        public IcecekController(IRepository repo, DrinkDiscoveryAdminContext _context, UserService _userService)
        {
            repository = repo;
            ViewBag.IcecekKategoriler = repository.IcecekKategoriler;
            ViewBag.TatlilarKategoriler = repository.TatlilarKategoriler;
            ViewBag.UrunKategoriler = repository.UrunKategoriler;
            ViewBag.Urunler = repository.Urunler;
            ViewBag.Tatlilar = repository.Tatlilar;
            ViewBag.Icecekler = repository.Icecekler;
            ViewBag.HaftaninIcecekleri = repository.Icecekler.Where(i => i.HaftaninIcecegi == true).ToList();
            context = _context;
            userService=_userService;
        }
        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var urun = repository.Icecekler.FirstOrDefault(i => i.IcecekId == id);
            if (urun != null && urun.IcecekResim != null)
            {
                return File(urun.IcecekResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult IcecekDetay(int id)
        {
            var selectedBeverage = repository.Icecekler
                                       .Include(i => i.IcecekKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.IcecekId == id);

            ViewBag.SelectedBeverage = selectedBeverage;
            ViewBag.SelectedBeverageCategory = selectedBeverage?.IcecekKategori;
            
            // yorumlar partial için eklendi
            int beverageId = ViewBag.SelectedBeverage.IcecekId;
            var yorumlar = repository.IcecekYorumlar.Where(i => i.YorumIcecekicecekId == beverageId)
                .Where(i => i.YorumOnay == true)
                .ToList();
            ViewBag.BeverageComments = yorumlar;
            // get usernames,photos etc.
            
            // username and user photo in one dictionary names user infos. key is username and value is photo
            var userInfos = getUserInfos(yorumlar);
            ViewBag.UserInfos = userInfos;

            return View();
        }

        public Dictionary<string, Tuple<string, byte[],int>> getUserInfos(List<IcecekYorumlar> yorumlar)
        {
            Dictionary<string, Tuple<string, byte[],int>> userInfos = new Dictionary<string, Tuple<string, byte[], int>>();
            foreach (var yorum in yorumlar)
            {
                
                var user = userService.GetUserDetailsByIdAsync(yorum.YorumKullaniciId);
                if (user != null)
                {
                    if (!userInfos.ContainsKey(yorum.YorumKullaniciId))
                    {
                        userInfos.Add(yorum.YorumKullaniciId, Tuple.Create(user.Result.kullanici_username, user.Result.kullanici_fotograf,yorum.YorumId));
                    }
                }
            }
            return userInfos;
        }


        public PartialViewResult IcecekKategorilerPartial()
        {
            return PartialView(repository.IcecekKategoriler);
        }


        

        

        [HttpPost]
        public async Task<IActionResult> IcecekYorumEkle(IcecekYorumlar yeni_yorum)
        {
            var icecekid = yeni_yorum.YorumIcecekicecekId;
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            // userid kullanarak userid nin username bilgisini al. bu sınıf context sınıfında yok. yukardaki gibi almak lazım
            
            //string name = user.Result.kullanici_ad;
            string time;

            var yorum_icerik = yeni_yorum.YorumIcerik;
            // Retrieve the drink entity from the repository based on the ID
            var icecek = repository.Icecekler.FirstOrDefault(i => i.IcecekId == icecekid);

            if (icecek != null)
            {
                //var user = userService.GetUserDetailsByIdAsync(userId);
                //if (user != null)
                //{
                //    var name = user.Result.kullanici_ad;
                //    var surname = user.Result.kullanici_soyad;
                //    var username = user.Result.kullanici_username;
                //}
                // Associate the drink entity with the new comment
                yeni_yorum.YorumIcecekicecek = icecek;
                yeni_yorum.YorumIcerik = yorum_icerik;
                yeni_yorum.YorumTarih = DateTime.Now;
                time = yeni_yorum.YorumTarih.ToString();
                // dd mm yyyy çevir
                time = time.Substring(0, 10);
                yeni_yorum.YorumKullaniciId = userId;
                yeni_yorum.YorumIcecekicecekId = icecekid;
                yeni_yorum.YorumPuan = 0;
                yeni_yorum.YorumOnay = true;

                
                
                
                // Assuming that the user ID is already set correctly in yeni_yorum
                repository.Add(yeni_yorum);
                
                // Save changes to the database (if using EF Core, typically you would call SaveChangesAsync)
                await repository.SaveChangesAsync();
            }
            else
            {
                // Return a NotFound result if the drink was not found
                return NotFound();
            }
           
            // Redirect to the IcecekDetay action, passing the drink ID as a parameter
            return RedirectToAction("IcecekDetay", new { id = icecekid });
        }


        public IActionResult DeleteComment(int id)
        {
            var yorumlar = repository.IcecekYorumlar.ToList();
            var yorum = repository.IcecekYorumlar.First(i => i.YorumId == id);
            var yorumicecekid = yorum.YorumIcecekicecekId;
            var yorumid = yorum.YorumId;
            var begenitablo = repository.UserProductCommentAction.Where(i => i.CommentId == yorumid).ToList();
            foreach (var item in begenitablo)
            {
                repository.Delete(item);
            }
            repository.Delete(yorum);
            return RedirectToAction("IcecekDetay", new {id = yorumicecekid});
        }

        public IActionResult LikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
            var yorum = repository.IcecekYorumlar.First(i => i.YorumId == id);
            var yorumicecekid = yorum.YorumIcecekicecekId;

            // Check if the user already liked/disliked the comment
            var existingAction = repository.UserBeverageCommentAction.FirstOrDefault(a => a.CommentId == id && a.UserId == userId);

            if (existingAction != null)
            {
                if (existingAction.IsLiked)
                {
                    // User already liked the comment, so do nothing or display a message
                    return RedirectToAction("IcecekDetay", new { id = yorumicecekid });
                }
                else
                {
                    // User disliked before, so reverse dislike and add a like
                    yorum.YorumDislikeCount--;
                    yorum.YorumLikeCount++;
                    existingAction.IsLiked = true; // Change to like
                }
            }
            else
            {
                // First time liking the comment
                yorum.YorumLikeCount++;
                UserBeverageCommentAction userBeverageCommentAction = new UserBeverageCommentAction
                {
                    UserId = userId,
                    CommentId = id,
                    IsLiked = true
                };
                repository.Add(userBeverageCommentAction);
            }

            repository.Update(yorum);
            repository.SaveChanges();

            return RedirectToAction("IcecekDetay", new { id = yorumicecekid });
        }



        public IActionResult DislikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
            var yorum = repository.IcecekYorumlar.First(i => i.YorumId == id);
            var yorumicecekid = yorum.YorumIcecekicecekId;

            // Check if the user already liked/disliked the comment
            var existingAction = repository.UserBeverageCommentAction.FirstOrDefault(a => a.CommentId == id && a.UserId == userId);

            if (existingAction != null)
            {
                if (!existingAction.IsLiked)
                {
                    // User already disliked the comment, so do nothing or display a message
                    return RedirectToAction("IcecekDetay", new { id = yorumicecekid });
                }
                else
                {
                    // User liked before, so reverse like and add a dislike
                    yorum.YorumLikeCount--;
                    yorum.YorumDislikeCount++;
                    existingAction.IsLiked = false; // Change to dislike
                }
            }
            else
            {
                // First time disliking the comment
                yorum.YorumDislikeCount++;
                UserBeverageCommentAction userBeverageCommentAction = new UserBeverageCommentAction
                {
                    UserId = userId,
                    CommentId = id,
                    IsLiked = false // Set the action as dislike
                };
                repository.Add(userBeverageCommentAction);
            }

            repository.Update(yorum);
            repository.SaveChanges();

            return RedirectToAction("IcecekDetay", new { id = yorumicecekid });
        }








    }
}
