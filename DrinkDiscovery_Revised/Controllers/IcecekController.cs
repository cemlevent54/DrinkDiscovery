﻿using DrinkDiscovery_Revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using DrinkDiscovery_Revised.Helpers;
using DrinkDiscovery_Revised.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
                .ToList();
            ViewBag.BeverageComments = yorumlar;
            // get usernames,photos etc.
            
            // username and user photo in one dictionary names user infos. key is username and value is photo
            var userInfos = getUserInfos(yorumlar);
            ViewBag.UserInfos = userInfos;




            //var model = new HomeViewModel(repository);
            //
            //{
            //    Icecekler = repository.Icecekler,
            //    IcecekKategoriler = repository.IcecekKategoriler,
            //    TatlilarKategoriler = repository.TatlilarKategoriler,
            //    UrunKategoriler = repository.UrunKategoriler,
            //};

            //return View(model);
            return View();
        }

        public Dictionary<string, Tuple<string, byte[]>> getUserInfos(List<IcecekYorumlar> yorumlar)
        {
            Dictionary<string, Tuple<string, byte[]>> userInfos = new Dictionary<string, Tuple<string, byte[]>>();
            foreach (var yorum in yorumlar)
            {
                var user = userService.GetUserDetailsByIdAsync(yorum.YorumKullaniciId);
                if (user != null)
                {
                    if (!userInfos.ContainsKey(yorum.YorumKullaniciId))
                    {
                        userInfos.Add(yorum.YorumKullaniciId, Tuple.Create(user.Result.kullanici_username, user.Result.kullanici_fotograf));
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

        

        
    }
}
