using DrinkDiscovery_Revised.Helpers;
using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace DrinkDiscovery_Revised.Controllers
{
    public class TatliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IRepository repository { get; set; }
        public UserService userService;

        public TatliController(IRepository repo, UserService _userservice)
        {
            repository = repo;
            ViewBag.IcecekKategoriler = repository.IcecekKategoriler;
            ViewBag.TatlilarKategoriler = repository.TatlilarKategoriler;
            ViewBag.UrunKategoriler = repository.UrunKategoriler;
            ViewBag.Urunler = repository.Urunler;
            ViewBag.Tatlilar = repository.Tatlilar;
            ViewBag.Icecekler = repository.Icecekler;
            ViewBag.HaftaninIcecekleri = repository.Icecekler.Where(i => i.HaftaninIcecegi == true).ToList();
            userService = _userservice;
        }

        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var tatli = repository.Tatlilar.FirstOrDefault(i => i.TatliId == id);
            if (tatli != null && tatli.TatliResim != null)
            {
                return File(tatli.TatliResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult TatliDetay(int id)
        {
            var selectedSweet = repository.Tatlilar
                                       .Include(i => i.TatliKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.TatliId == id);

            ViewBag.SelectedSweet = selectedSweet;
            ViewBag.SelectedSweetCategory = selectedSweet?.TatliKategori;

            // yorumlar partial için eklendi
            int sweetId = ViewBag.SelectedSweet.TatliId;
            var yorumlar = repository.TatlilarYorumlar.Where(i => i.YorumTatlitatliId == sweetId)
                .ToList();

            ViewBag.SweetComments = yorumlar;

            // user infos 
            var userInfos = getUserInfos(yorumlar);
            ViewBag.UserInfos = userInfos;

            return View();
        }
        
        public Dictionary<string, Tuple<string, byte[], int>> getUserInfos(List<TatlilarYorumlar> yorumlar)
        {
            Dictionary<string, Tuple<string, byte[], int>> userInfos = new Dictionary<string, Tuple<string, byte[], int>>();
            foreach (var yorum in yorumlar)
            {

                if (yorum?.YorumKullaniciId != null) // Check if yorum and YorumKullaniciId are not null
                {
                    var user = userService.GetUserDetailsByIdAsync(yorum.YorumKullaniciId);
                    if (user != null)
                    {
                        if (!userInfos.ContainsKey(yorum.YorumKullaniciId))
                        {
                            userInfos.Add(yorum.YorumKullaniciId, Tuple.Create(user.Result.kullanici_username, user.Result.kullanici_fotograf, yorum.YorumId));
                        }
                    }
                }
            }
            return userInfos;
        }

        [HttpPost]
        public async Task<IActionResult> TatliYorumEkle(TatlilarYorumlar yeni_yorum)
        {
            var tatliid = yeni_yorum.YorumTatlitatliId;
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            // userid kullanarak userid nin username bilgisini al. bu sınıf context sınıfında yok. yukardaki gibi almak lazım

            //string name = user.Result.kullanici_ad;
            string time;

            var yorum_icerik = yeni_yorum.YorumIcerik;
            // Retrieve the drink entity from the repository based on the ID
            var tatli = repository.Tatlilar.FirstOrDefault(i => i.TatliId == tatliid);

            if (tatli != null)
            {
                
                // Associate the drink entity with the new comment
                yeni_yorum.YorumTatlitatli = tatli;
                yeni_yorum.YorumIcerik = yorum_icerik;
                yeni_yorum.YorumTarih = DateTime.Now;
                time = yeni_yorum.YorumTarih.ToString();
                // dd mm yyyy çevir
                time = time.Substring(0, 10);
                yeni_yorum.YorumKullaniciId = userId;
                yeni_yorum.YorumTatlitatliId = tatliid;
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
            return RedirectToAction("TatliDetay", new { id = tatliid });
        }

        public IActionResult DeleteComment(int id)
        {
            var yorumlar = repository.TatlilarYorumlar.ToList();
            var yorum = repository.TatlilarYorumlar.First(i => i.YorumId == id);
            var yorumtatliid = yorum.YorumTatlitatliId;
            var yorumid = yorum.YorumId;
            // yorum silindiğinde yoruma ait beğeni tablosunu da sil
            var begenitablo = repository.UserSweetCommentAction.Where(i => i.CommentId == yorumid).ToList();
            foreach (var item in begenitablo)
            {
                repository.Delete(item);
            }
            repository.Delete(yorum);
            return RedirectToAction("TatliDetay", new { id = yorumtatliid });
        }

        public IActionResult LikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
            var yorum = repository.TatlilarYorumlar.First(i => i.YorumId == id);
            var yorumtatliid = yorum.YorumTatlitatliId;

            // Check if the user already liked/disliked the comment
            var existingAction = repository.UserSweetCommentAction.FirstOrDefault(a => a.CommentId == id && a.UserId == userId);

            if (existingAction != null)
            {
                if (existingAction.IsLiked)
                {
                    // User already liked the comment, so do nothing or display a message
                    return RedirectToAction("TatliDetay", new { id = yorumtatliid });
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
                UserSweetCommentAction userSweetCommentAction = new UserSweetCommentAction
                {
                    UserId = userId,
                    CommentId = id,
                    IsLiked = true
                };
                repository.Add(userSweetCommentAction);
            }

            repository.Update(yorum);
            repository.SaveChanges();

            return RedirectToAction("TatliDetay", new { id = yorumtatliid });
        }



        public IActionResult DislikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
            var yorum = repository.TatlilarYorumlar.First(i => i.YorumId == id);
            var yorumtatliid = yorum.YorumTatlitatliId;

            // Check if the user already liked/disliked the comment
            var existingAction = repository.UserSweetCommentAction.FirstOrDefault(a => a.CommentId == id && a.UserId == userId);

            if (existingAction != null)
            {
                if (!existingAction.IsLiked)
                {
                    // User already disliked the comment, so do nothing or display a message
                    return RedirectToAction("TatliDetay", new { id = yorumtatliid });
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
                UserSweetCommentAction userSweetCommentAction = new UserSweetCommentAction
                {
                    UserId = userId,
                    CommentId = id,
                    IsLiked = false // Set the action as dislike
                };
                repository.Add(userSweetCommentAction);
            }

            repository.Update(yorum);
            repository.SaveChanges();

            return RedirectToAction("TatliDetay", new { id = yorumtatliid });
        }
    }
}
