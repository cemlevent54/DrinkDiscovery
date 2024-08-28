using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Revised.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IRepository repository;
        public UserService userService;
        public UrunController(IRepository _repository, UserService _userService)
        {
            repository = _repository;
            userService=_userService;
        }

        public IActionResult GetImage(int id)
        {
            //var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == id);
            if (urun != null && urun.UrunResim != null)
            {
                return File(urun.UrunResim, "image/jpeg");
            }
            return NotFound();
        }

        public IActionResult UrunDetay(int id)
        {
            var selectedProduct = repository.Urunler
                                       .Include(i => i.UrunKategori) // Ensure you include the related category
                                       .FirstOrDefault(i => i.UrunId == id);

            ViewBag.SelectedProduct = selectedProduct;
            ViewBag.SelectedProductCategory = selectedProduct?.UrunKategori;

            //var model = new HomeViewModel(repository);
            ////
            ///
            
            // yorumlar partial için eklendi
            int productId = ViewBag.selectedProduct.UrunId;
            var yorumlar = repository.UrunYorumlar.Where(i => i.YorumUrunurunId == productId)
                .ToList();
            ViewBag.ProductComments = yorumlar;

            // user infos
            var userInfos = getUserInfos(yorumlar);
            ViewBag.UserInfos = userInfos;


            return View();
        }

        public Dictionary<string, Tuple<string, byte[], int>> getUserInfos(List<UrunlerYorumlar> yorumlar)
        {
            Dictionary<string, Tuple<string, byte[], int>> userInfos = new Dictionary<string, Tuple<string, byte[], int>>();
            foreach (var yorum in yorumlar)
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
            return userInfos;
        }

        [HttpPost]
        public async Task<IActionResult> UrunYorumEkle(UrunlerYorumlar yeni_yorum)
        {
            var urunid = yeni_yorum.YorumUrunurunId;
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            string time;

            var yorum_icerik = yeni_yorum.YorumIcerik;
            // Retrieve the drink entity from the repository based on the ID
            var urun = repository.Urunler.FirstOrDefault(i => i.UrunId == urunid);

            if (urun != null)
            {
                
                // Associate the drink entity with the new comment
                yeni_yorum.YorumUrunurun = urun;
                yeni_yorum.YorumIcerik = yorum_icerik;
                yeni_yorum.YorumTarih = DateTime.Now;
                time = yeni_yorum.YorumTarih.ToString();
                // dd mm yyyy çevir
                time = time.Substring(0, 10);
                yeni_yorum.YorumKullaniciId = userId;
                yeni_yorum.YorumUrunurunId = urunid;
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
            return RedirectToAction("UrunDetay", new { id = urunid });
        }


        public IActionResult DeleteComment(int id)
        {
            var yorumlar = repository.UrunYorumlar.ToList();
            var yorum = repository.UrunYorumlar.First(i => i.YorumId == id);
            var yorumurunid = yorum.YorumUrunurunId;
            repository.Delete(yorum);
            return RedirectToAction("UrunDetay", new { id = yorumurunid });
        }
    }
}
